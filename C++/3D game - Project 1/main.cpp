#pragma comment(lib, "glew32.lib")
#pragma comment(lib, "opengl32.lib")

#include <Windows.h>
#include <fstream>
#include <sstream>
#include <GL\glew.h>
#include <GL\wglew.h>

#include <string>
using std::string;


struct WindowStruct {
	HINSTANCE hInstance;
	HWND hWnd;
};

struct Context {
	HGLRC hrc;
	HDC hdc;
};

/*
	Declaring ConfigData struct type
*/
struct ConfigData {
	string title;
	int positionX;
	int positionY;
	int width;
	int height;
	float backgroundRed;
	float backgroundGreen;
	float backgroundBlue;
	float backgroundAlpha;
};


ConfigData config; // Declaring C++ style structure 

/*
	Method takes two arguments; a text filename to read it and the instance of struct
	ConfigData to store all the reading input from text file.
	return: N/A
*/
void ReadConfigData(string fileName, ConfigData& config) {
	string line;
	std::ifstream fin;
	fin.open(fileName);
	while (!fin.eof()) {
		getline(fin, line);
		std::istringstream readLine;						// holds a sequence of characters
		readLine.str(line.substr(line.find(":") + 1));

		if (line.find("title") != -1) {						// check if the word "title" in a line
			int lenth = line.size();						// stores the size of the string
			int index = line.find_first_of(":", 0);			// finds the length of string from first character to the ":" sign*/
			string title = line.substr(index + 2, lenth);	// stores all characters from the ":" sign to end
			config.title = title;
		}
		else if (line.find("initial position x") != -1) {	//check if "initial positon x" in line, stores position x in config
			readLine >> config.positionX;
		}
		else if (line.find("initial position y") != -1) {	//check if "initial positon y" in line, stores position y in config
			readLine >> config.positionY;
		}
		else if (line.find("width") != -1) {	//check if "width" in line,store width of window in config
			readLine >> config.width;
		}
		else if (line.find("height") != -1) {	//check if "height" in line, store width of window in config
			readLine >> config.height;
		}
		else if (line.find("background red") != -1) {	//check if "background red" in line, stores the color in config
			readLine >> config.backgroundRed;
		}
		else if (line.find("background green") != -1) {		//check if "background green" in line, stores the color in config
			readLine >> config.backgroundGreen;
		}
		else if (line.find("background blue") != -1) {		//check if "background blue" in line, stores the color in config
			readLine >> config.backgroundBlue;
		}
		else if (line.find("background alpha") != -1) {		//check if "background alpha" in line, stores the color in config
			readLine >> config.backgroundAlpha;
		}
	}
	fin.close();
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message) {
	case WM_CLOSE:
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	}

	return DefWindowProc(hWnd, message, wParam, lParam);
}

WindowStruct CreateCustomWindow(const string& title)
{
	WindowStruct window;
	window.hInstance = 0;
	window.hWnd = NULL;

	window.hInstance = GetModuleHandle(NULL);
	if (window.hInstance == 0) return window;

	WNDCLASS windowClass;
	windowClass.style = CS_HREDRAW | CS_VREDRAW | CS_OWNDC;
	windowClass.lpfnWndProc = (WNDPROC)WndProc;
	windowClass.cbClsExtra = 0;
	windowClass.cbWndExtra = 0;
	windowClass.hInstance = window.hInstance;
	windowClass.hIcon = LoadIcon(NULL, IDI_WINLOGO);
	windowClass.hCursor = LoadCursor(NULL, IDC_ARROW);
	windowClass.hbrBackground = NULL;
	windowClass.lpszMenuName = NULL;
	windowClass.lpszClassName = title.c_str();

	if (!RegisterClass(&windowClass)) {
		window.hInstance = 0;
		window.hWnd = NULL;
		return window;
	}

	window.hWnd = CreateWindowEx(
		WS_EX_APPWINDOW | WS_EX_WINDOWEDGE,
		title.c_str(),
		title.c_str(),
		WS_OVERLAPPEDWINDOW,
		config.positionX, config.positionY, config.width, config.height,
		NULL,
		NULL,
		window.hInstance,
		NULL
		);

	if (window.hWnd == NULL) {
		window.hInstance = 0;
		window.hWnd = NULL;
	}

	return window;
}

void MessageLoop(const Context& context)
{
	bool timeToExit = false;
	MSG msg;
	while (!timeToExit) {
		if (PeekMessage(&msg, NULL, 0, 0, PM_REMOVE)) {
			if (msg.message == WM_QUIT) {
				timeToExit = true;
			}
			else {
				TranslateMessage(&msg);
				DispatchMessage(&msg);
			}
		}
		else {
			glViewport(0, 0, 500, 500);
			glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT | GL_STENCIL_BUFFER_BIT);
			SwapBuffers(context.hdc);
		}

	}
}

Context CreateOGLWindow(const WindowStruct& window)
{
	Context context;
	context.hdc = NULL;
	context.hrc = NULL;

	if (window.hWnd == NULL) return context;

	context.hdc = GetDC(window.hWnd);
	if (context.hdc == NULL) return context;

	PIXELFORMATDESCRIPTOR pfd;
	memset(&pfd, 0, sizeof(PIXELFORMATDESCRIPTOR));
	pfd.nSize = sizeof(PIXELFORMATDESCRIPTOR);
	pfd.dwFlags = PFD_DOUBLEBUFFER | PFD_SUPPORT_OPENGL | PFD_DRAW_TO_WINDOW;
	pfd.iPixelType = PFD_TYPE_RGBA;
	pfd.cColorBits = 32;
	pfd.cDepthBits = 32;

	int pixelFormat = ChoosePixelFormat(context.hdc, &pfd);
	if (pixelFormat == 0) {
		context.hdc = NULL;
		context.hrc = NULL;
		return context;
	}

	BOOL result = SetPixelFormat(context.hdc, pixelFormat, &pfd);
	if (!result) {
		context.hdc = NULL;
		context.hrc = NULL;
		return context;
	}

	HGLRC tempOpenGLContext = wglCreateContext(context.hdc);
	wglMakeCurrent(context.hdc, tempOpenGLContext);

	if (glewInit() != GLEW_OK) {
		context.hdc = NULL;
		context.hrc = NULL;
		return context;
	}

	return context;
}

void ShowWindow(HWND hWnd)
{
	if (hWnd != NULL) {
		ShowWindow(hWnd, SW_SHOW);
		UpdateWindow(hWnd);
	}
}

void CleanUp(const WindowStruct& window, const Context& context)
{
	if (context.hdc != NULL) {
		wglMakeCurrent(context.hdc, 0);
		wglDeleteContext(context.hrc);
		ReleaseDC(window.hWnd, context.hdc);
	}
}


int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	ReadConfigData("window.config.txt", config);	// invoke the method readConfigData with two arguments file name
													// and instance of configData struct

	WindowStruct window = CreateCustomWindow(config.title);
	if (window.hWnd != NULL) {
		Context context = CreateOGLWindow(window);
		if (context.hdc != NULL) {
			ShowWindow(window.hWnd);

			//changes rgba color of background based on config values
			glClearColor(config.backgroundRed, config.backgroundGreen, config.backgroundBlue, config.backgroundAlpha);
			MessageLoop(context);
			CleanUp(window, context);
		}
	}
	return 0;
}


