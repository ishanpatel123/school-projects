#include "OGLShader.h"
#include "WindowsConsoleLogger.h"

#include <cstdlib>
#include <fstream>
#include <sstream>
#include <string>
using namespace std;
OGLShader::OGLShader(void)
{
	// Points ///////////////////////////////////////////////////////////
	// Point 1
	//pointsVertexData[0].x = -0.1f;
	//pointsVertexData[0].y = 0.1f;
	//pointsVertexData[0].z = 0.0f;
	//pointsVertexData[0].red = 1.0f;
	//pointsVertexData[0].green = 0.0f;
	//pointsVertexData[0].blue = 0.0f;
	//// Point 2
	//pointsVertexData[1].x = -0.1f;
	//pointsVertexData[1].y = -0.1f;
	//pointsVertexData[1].z = 0.0f;
	//pointsVertexData[1].red = 0.0f;
	//pointsVertexData[1].green = 1.0f;
	//pointsVertexData[1].blue = 0.0f;
	//// Point 3
	//pointsVertexData[2].x = 0.1f;
	//pointsVertexData[2].y = -0.1f;
	//pointsVertexData[2].z = 0.0f;
	//pointsVertexData[2].red = 0.0f;
	//pointsVertexData[2].green = 0.0f;
	//pointsVertexData[2].blue = 1.0f;
	//// Point 4
	//pointsVertexData[3].x = 0.1f;
	//pointsVertexData[3].y = 0.1f;
	//pointsVertexData[3].z = 0.0f;
	//pointsVertexData[3].red = 0.0f;
	//pointsVertexData[3].green = 1.0f;
	//pointsVertexData[3].blue = 1.0f;

	//// Lines ////////////////////////////////////////////////////////////
	//// X axis line
	//linesVertexData[0].x = -1.0f;
	//linesVertexData[0].y = 0.0f;
	//linesVertexData[0].z = 0.0f;
	//linesVertexData[0].red = 1.0f;
	//linesVertexData[0].green = 0.0f;
	//linesVertexData[0].blue = 0.0f;
	//linesVertexData[1].x = 1.0f;
	//linesVertexData[1].y = 0.0f;
	//linesVertexData[1].z = 0.0f;
	//linesVertexData[1].red = 1.0f;
	//linesVertexData[1].green = 0.0f;
	//linesVertexData[1].blue = 0.0f;
	//// Y axis line
	//linesVertexData[2].x = 0.0f;
	//linesVertexData[2].y = 1.0f;
	//linesVertexData[2].z = 0.0f;
	//linesVertexData[2].red = 0.0f;
	//linesVertexData[2].green = 1.0f;
	//linesVertexData[2].blue = 0.0f;
	//linesVertexData[3].x = 0.0f;
	//linesVertexData[3].y = -1.0f;
	//linesVertexData[3].z = 0.0f;
	//linesVertexData[3].red = 0.0f;
	//linesVertexData[3].green = 1.0f;
	//linesVertexData[3].blue = 0.0f;

	//this->myLine[0].x = 0.9f;
	//this->myLine[0].y = -0.9f;
	//this->myLine[0].z = 0.0f;
	//this->myLine[0].red = 0.0f;
	//this->myLine[0].green = 1.0f;
	//this->myLine[0].blue = 0.0f;
	//this->myLine[1].x = 0.7f;
	//this->myLine[1].y = -0.7f;
	//this->myLine[1].z = 0.0f;
	//this->myLine[1].red = 0.0f;
	//this->myLine[1].green = 1.0f;
	//this->myLine[1].blue = 0.0f;


	//this->myLine1[0].x = 0.4f;
	//this->myLine1[0].y = -0.6f;
	//this->myLine1[0].z = 0.0f;
	//this->myLine1[0].red = 0.0f;
	//this->myLine1[0].green = 1.0f;
	//this->myLine1[0].blue = 0.0f;

	//this->myLine1[1].x = 0.6f;
	//this->myLine1[1].y = 0.0f;
	//this->myLine1[1].z = 0.0f;
	//this->myLine1[1].red = 0.0f;
	//this->myLine1[1].green = 1.0f;
	//this->myLine1[1].blue = 0.0f;

	//this->myLine1[2].x = 0.6f;
	//this->myLine1[2].y = 0.0f;
	//this->myLine1[2].z = 0.0f;
	//this->myLine1[2].red = 0.0f;
	//this->myLine1[2].green = 1.0f;
	//this->myLine1[2].blue = 0.0f;

	//this->myLine1[3].x = 0.4f;
	//this->myLine1[3].y = 0.6f;
	//this->myLine1[3].z = 0.0f;
	//this->myLine1[3].red = 0.0f;
	//this->myLine1[3].green = 1.0f;
	//this->myLine1[3].blue = 0.0f;

	//this->myLine1[4].x = 0.4f;
	//this->myLine1[4].y = 0.6f;
	//this->myLine1[4].z = 0.0f;
	//this->myLine1[4].red = 0.0f;
	//this->myLine1[4].green = 1.0f;
	//this->myLine1[3].blue = 0.0f;

	//this->myLine1[5].x = -0.4f;
	//this->myLine1[5].y = 0.6f;
	//this->myLine1[5].z = 0.0f;
	//this->myLine1[5].red = 0.0f;
	//this->myLine1[5].green = 1.0f;
	//this->myLine1[5].blue = 0.0f;

	//this->myLine1[6].x = -0.4f;
	//this->myLine1[6].y = 0.6f;
	//this->myLine1[6].z = 0.0f;
	//this->myLine1[6].red = 0.0f;
	//this->myLine1[6].green = 1.0f;
	//this->myLine1[6].blue = 0.0f;

	//this->myLine1[7].x = -0.6f;
	//this->myLine1[7].y = 0.0f;
	//this->myLine1[7].z = 0.0f;
	//this->myLine1[7].red = 0.0f;
	//this->myLine1[7].green = 1.0f;
	//this->myLine1[7].blue = 0.0f;

	//this->myLine1[8].x = -0.6f;
	//this->myLine1[8].y = 0.0f;
	//this->myLine1[8].z = 0.0f;
	//this->myLine1[8].red = 0.0f;
	//this->myLine1[8].green = 1.0f;
	//this->myLine1[8].blue = 0.0f;

	//this->myLine1[9].x = -0.4f;
	//this->myLine1[9].y = -0.6f;
	//this->myLine1[9].z = 0.0f;
	//this->myLine1[9].red = 0.0f;
	//this->myLine1[9].green = 1.0f;
	//this->myLine1[9].blue = 0.0f;

	//this->myLine1[10].x = -0.4f;
	//this->myLine1[10].y = -0.6f;
	//this->myLine1[10].z = 0.0f;
	//this->myLine1[10].red = 0.0f;
	//this->myLine1[10].green = 1.0f;
	//this->myLine1[10].blue = 0.0f;

	//this->myLine1[11].x = 0.4f;
	//this->myLine1[11].y = -0.6f;
	//this->myLine1[11].z = 0.0f;
	//this->myLine1[11].red = 0.0f;
	//this->myLine1[11].green = 1.0f;
	//this->myLine1[11].blue = 0.0f;

	//// Triangles ////////////////////////////////////////////////////////
	//// First triangle
	//trianglesVertexData[0].x = -0.3f;
	//trianglesVertexData[0].y = 0.0f;
	//trianglesVertexData[0].z = 0.0f;
	//trianglesVertexData[0].red = 1.0f;
	//trianglesVertexData[0].green = 0.0f;
	//trianglesVertexData[0].blue = 0.0f;
	//trianglesVertexData[1].x = -0.4f;
	//trianglesVertexData[1].y = 0.5f;
	//trianglesVertexData[1].z = 0.0f;
	//trianglesVertexData[1].red = 0.0f;
	//trianglesVertexData[1].green = 0.0f;
	//trianglesVertexData[1].blue = 1.0f;
	//trianglesVertexData[2].x = -0.5f;
	//trianglesVertexData[2].y = 0.0f;
	//trianglesVertexData[2].z = 0.0f;
	//trianglesVertexData[2].red = 0.0f;
	//trianglesVertexData[2].green = 1.0f;
	//trianglesVertexData[2].blue = 0.0f;
	//// Second triangle
	//trianglesVertexData[3].x = 0.4f;
	//trianglesVertexData[3].y = 0.5f;
	//trianglesVertexData[3].z = 0.0f;
	//trianglesVertexData[3].red = 0.0f;
	//trianglesVertexData[3].green = 1.0f;
	//trianglesVertexData[3].blue = 0.0f;
	//trianglesVertexData[4].x = 0.5f;
	//trianglesVertexData[4].y = 0.0f;
	//trianglesVertexData[4].z = 0.0f;
	//trianglesVertexData[4].red = 0.0f;
	//trianglesVertexData[4].green = 0.0f;
	//trianglesVertexData[4].blue = 1.0f;
	//trianglesVertexData[5].x = 0.6f;
	//trianglesVertexData[5].y = 0.5f;
	//trianglesVertexData[5].z = 0.0f;
	//trianglesVertexData[5].red = 0.0f;
	//trianglesVertexData[5].green = 1.0f;
	//trianglesVertexData[5].blue = 1.0f;

	//this->myTriangle[0].x = -0.8f;
	//this->myTriangle[0].y = -0.8f;
	//this->myTriangle[0].z = 0.0f;
	//this->myTriangle[0].red = 1.0f;
	//this->myTriangle[0].green = 0.0f;
	//this->myTriangle[0].blue = 0.0f;
	//this->myTriangle[1].x = -0.6f;
	//this->myTriangle[1].y = -0.9f;
	//this->myTriangle[1].z = 0.0f;
	//this->myTriangle[1].red = 1.0f;
	//this->myTriangle[1].green = 0.0f;
	//this->myTriangle[1].blue = 0.0f;
	//this->myTriangle[2].x = -0.9f;
	//this->myTriangle[2].y = -0.9f;
	//this->myTriangle[2].z = 0.0f;
	//this->myTriangle[2].red = 1.0f;
	//this->myTriangle[2].green = 0.0f;
	//this->myTriangle[2].blue = 0.0f;

	//this->myPoint.x = 0.9f;
	//this->myPoint.y = 0.9f;
	//this->myPoint.z = 0.0f;
	//this->myPoint.red = 1.0f;
	//this->myPoint.green = 1.0f;
	//this->myPoint.blue = 1.0f;

string line, value;
int changeShapeNum = 0, changeVACount = 0, count = 1;

ifstream fin;
fin.open("data.txt");

while (getline(fin, line))
{
	stringstream   linestream(line);
	fin >> myTriangle[0].x >> myTriangle[0].y >> myTriangle[0].z >> myTriangle[0].red >> myTriangle[0].green >> myTriangle[0].blue;
	//while (getline(linestream, value, ',') && changeVACount < (sizeof(myTriangle) / sizeof(*myTriangle)))
	//{
	//	if (line.find("//") != -1) {
	//		changeShapeNum++;
	//	}
	//	else {
	//		line >> myTriangle[0].x;
	//		//cout << "Value(" << value << ")\n";
	//		if (changeShapeNum == 1)
	//		{
	//			string::size_type sz;     // alias of size_t
	//			float mars = stof(value, &sz);
	//			if (count == 1) {
	//				myTriangle[changeVACount].x = mars;
	//				count++;
	//			}
	//			else if (count == 2) {
	//				myTriangle[changeVACount].y = mars;
	//				count++;
	//			}
	//			else if (count == 3) {
	//				myTriangle[changeVACount].z = mars;
	//				count++;
	//			}
	//			else if (count == 4) {
	//				myTriangle[changeVACount].red = mars;
	//				count++;
	//			}
	//			else if (count == 5) {
	//				myTriangle[changeVACount].green = mars;
	//				count++;
	//			}
	//			else if (count == 6) {
	//				myTriangle[changeVACount].blue = mars;
	//				count = 1;
	//				changeVACount++;
	//			}
	//		}
	//		else if (changeShapeNum == 2)
	//		{
	//			string::size_type sz;     // alias of size_t
	//			float mars = stof(value, &sz);
	//		}
	//		else if (changeShapeNum == 3)
	//		{
	//			string::size_type sz;     // alias of size_t
	//			float mars = stof(value, &sz);
	//		}
	//	}
	//}
}
fin.close();
}

OGLShader::~OGLShader(void)
{
	glDeleteVertexArrays(1, &vaoId);
}

bool OGLShader::create()
{
	if (!this->setupShaders()) return false;
	this->createPrimitives();
	return true;
}

void OGLShader::renderObjects()
{
	this->renderTriangles(this->trianglesVboId, 6);
	this->renderLines(this->linesVboId, 4);
	this->renderPoints(this->pointsVboId, 4);
	this->renderPoints(this->myPointVbo, 1);
	this->renderLines(this->myLineVbo,2);
	this->renderLines(this->myLineVbo1, 12);

	this->renderTriangles(this->myTriangleVbo, 3);

}

bool OGLShader::setupShaders()
{
	GLchar* vertexSource =
		"#version 330\n"\
		"layout(location = 0) in vec3 position;\n"\
		"layout(location = 1) in vec3 vertexColor;\n"\
		"out vec4 fragColor;\n"\
		"void main()\n"\
		"{\n"\
		"   gl_Position = vec4(position, 1.0);\n" \
		"   fragColor = vec4(vertexColor, 1.0);\n" \
		"}\n";
	vertexShader = compileShader(GL_VERTEX_SHADER, vertexSource);
	if (vertexShader == 0) return false;

	GLchar* fragmentSource =
		"#version 330\n"\
		"in vec4 fragColor;\n"\
		"out vec4 color;\n"\
		"void main()\n"\
		"{\n"\
		"   color = fragColor;\n"\
		"}\n";
	fragmentShader = compileShader(GL_FRAGMENT_SHADER, fragmentSource);
	if (fragmentShader == 0) return false;

	shaderProgram = linkShader(vertexShader, fragmentShader);
	glDeleteShader(vertexShader);
	glDeleteShader(fragmentShader);
	return true;
}

GLuint OGLShader::compileShader(GLenum type, const GLchar* source)
{
	GLint length = sizeof(GLchar) * strlen(source);
	GLuint shader = glCreateShader(type);
	glShaderSource(shader, 1, (const GLchar**)&source, &length);
	glCompileShader(shader);
	GLint shaderOk = 0;
	glGetShaderiv(shader, GL_COMPILE_STATUS, &shaderOk);
	if (!shaderOk) {
		logger->log("makeShader: Failed to compile the shader!");
		showInfoLog(shader, glGetShaderiv, glGetShaderInfoLog);
		glDeleteShader(shader);
		shader = 0;
	}
	return shader;
}

GLuint OGLShader::linkShader(GLuint vertexShader, GLuint fragmentShader)
{
	GLuint program = glCreateProgram();
	glAttachShader(program, vertexShader);
	glAttachShader(program, fragmentShader);
	glLinkProgram(program);
	GLint programOk = 0;
	glGetProgramiv(program, GL_LINK_STATUS, &programOk);
	if (!programOk) {
		logger->log("linkShader: Failed to link the shader!");
		showInfoLog(program, glGetProgramiv, glGetProgramInfoLog);
		glDeleteShader(program);
		program = 0;
	}
	return program;
}

void OGLShader::showInfoLog(GLuint object, PFNGLGETSHADERIVPROC glGet__iv, PFNGLGETSHADERINFOLOGPROC glGet__InfoLog)
{
	GLint logLength;
	glGet__iv(object, GL_INFO_LOG_LENGTH, &logLength);
	char* log = (char*)malloc(logLength);
	glGet__InfoLog(object, logLength, NULL, log);
	logger->log(string(log));
	free(log);
}

void OGLShader::createPrimitives()
{
	glGenVertexArrays(1, &vaoId);
	glBindVertexArray(vaoId);
	trianglesVboId = createVBOHandle(
		GL_ARRAY_BUFFER, trianglesVertexData, sizeof(trianglesVertexData));

	linesVboId = createVBOHandle(
		GL_ARRAY_BUFFER, linesVertexData, sizeof(linesVertexData));

	pointsVboId = createVBOHandle(
		GL_ARRAY_BUFFER, pointsVertexData, sizeof(pointsVertexData));

	this->myPointVbo = this->createVBOHandle(
		GL_ARRAY_BUFFER,
		&(this->myPoint),
		sizeof(this->myPoint)
		);
	this->myLineVbo = this->createVBOHandle(
		GL_ARRAY_BUFFER,
		this->myLine,
		sizeof(this->myLine)
		);
	this->myLineVbo1 = this->createVBOHandle(
		GL_ARRAY_BUFFER,
		this->myLine1,
		sizeof(this->myLine1)
		);
	this->myTriangleVbo = this->createVBOHandle(
		GL_ARRAY_BUFFER,
		this->myTriangle,
		sizeof(this->myTriangle)
		);
	glBindVertexArray(0);
}

GLuint OGLShader::createVBOHandle(GLenum target, const void* bufferData, GLsizei bufferSize)
{
	GLuint vboID = 0;
	// Declare the buffer object and store a handle to the object
	glGenBuffers(1, &vboID);
	// Bind the object to the binding target
	glBindBuffer(target, vboID);
	// Allocate memory in the GPU for the buffer bound to the binding target and then copy the data
	glBufferData(target, bufferSize, bufferData, GL_STATIC_DRAW);
	// Good practice to cleanup by unbinding 
	glBindBuffer(target, 0);
	return vboID;
}

void OGLShader::renderTriangles(GLuint vbo, GLsizei numberOfVertices)
{
	glBindVertexArray(vaoId);
	glUseProgram(shaderProgram);
	glBindBuffer(GL_ARRAY_BUFFER, vbo);

	enablePositionsAndColor();

	glDrawArrays(GL_TRIANGLES, 0, numberOfVertices);

	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glUseProgram(0);
	glBindVertexArray(0);
}

void OGLShader::renderLines(GLuint vbo, GLsizei numberOfVertices)
{
	glBindVertexArray(vaoId);
	glUseProgram(shaderProgram);
	glBindBuffer(GL_ARRAY_BUFFER, vbo);

	enablePositionsAndColor();

	glDrawArrays(GL_LINES, 0, numberOfVertices);

	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glUseProgram(0);
	glBindVertexArray(0);
}

void OGLShader::renderPoints(GLuint vbo, GLsizei numberOfVertices)
{
	glBindVertexArray(vaoId);
	glUseProgram(shaderProgram);
	glBindBuffer(GL_ARRAY_BUFFER, vbo);

	enablePositionsAndColor();

	glDrawArrays(GL_POINTS, 0, numberOfVertices);

	glDisableVertexAttribArray(0);
	glDisableVertexAttribArray(1);
	glUseProgram(0);
	glBindVertexArray(0);
}

void OGLShader::enablePositionsAndColor()
{
	// Positions
	glEnableVertexAttribArray(0);
	glVertexAttribPointer(
		0,
		3,              // Each position has 3 components
		GL_FLOAT,       // Each component is a 32-bit floating point value
		GL_FALSE,
		sizeof(Vertex), // The number of bytes to the next position
		(void*)0        // Byte offset of the first position in the array
		);
	// Colors
	glEnableVertexAttribArray(1);
	glVertexAttribPointer(
		1,
		3,                          // Each color has 3 components
		GL_FLOAT,                   // Each component is a 32-bit floating point value
		GL_FALSE,
		sizeof(Vertex),             // The number of bytes to the next color
		(void*)(sizeof(GLfloat) * 3) // Byte offset of the first color in the array
		);
}


