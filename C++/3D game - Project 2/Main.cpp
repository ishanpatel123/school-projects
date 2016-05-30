#pragma comment(lib, "glew32.lib")
#pragma comment(lib, "opengl32.lib")

#include "WindowsConsoleLogger.h"
#include "GameWindow.h"
#include "OGLShader.h"

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	Logger* logger = new WCLogger();

	Shader* shader = new OGLShader();
	shader->setLogger(logger);

	GenericWindow *window = new GameWindow(shader, L"The Game Window", 1000, 800);
	window->setLogger(logger);
	if (window->create()) {
		window->show();
		window->listenForEvents();
	}

	delete window;
	delete shader;
	delete logger;
	return 0;
}
