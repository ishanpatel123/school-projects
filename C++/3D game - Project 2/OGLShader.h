#pragma once
#ifndef OGL_SHADER
#define OGL_SHADER

#include "Shader.h"

#include <gl/glew.h>

class Logger;

class OGLShader : public Shader
{
protected:
	struct Vertex {
		GLfloat x, y, z;
		GLfloat red, green, blue;
	}trianglesVertexData[6], linesVertexData[4], pointsVertexData[4];

	GLuint vertexShader, fragmentShader, shaderProgram;

	GLuint trianglesVboId, linesVboId, pointsVboId;

	GLuint vaoId;
	Vertex myPoint;
	GLuint myPointVbo;

	Vertex myLine[2];
	GLuint myLineVbo;

	Vertex myLine1[12];
	GLuint myLineVbo1;

	Vertex myTriangle[62];
	GLuint myTriangleVbo;

public:
	OGLShader(void);
	~OGLShader(void);

	bool create();
	void renderObjects();

protected:
	bool setupShaders();
	void createPrimitives();
	void renderTriangles(GLuint vbo, GLsizei numberOfVertices);
	void renderLines(GLuint vbo, GLsizei numberOfVertices);
	void renderPoints(GLuint vbo, GLsizei numberOfVertices);

	GLuint createVBOHandle(GLenum target, const void* bufferData, GLsizei bufferSize);
	GLuint compileShader(GLenum type, const GLchar* source);
	void showInfoLog(GLuint object, PFNGLGETSHADERIVPROC glGet__iv, PFNGLGETSHADERINFOLOGPROC glGet__InfoLog);
	GLuint linkShader(GLuint vertexShader, GLuint fragmentShader);

	void enablePositionsAndColor();
};

#endif

