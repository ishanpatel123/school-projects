#pragma once
#ifndef OGL_GAME_OBJECT
#define OGL_GAME_OBJECT

#include "GameObject.h"

#include <string>
using std::string;

#include <gl\glew.h>

class OGLGameObject :
	public GameObject
{
public:
	GLuint vao;

protected:
	GLuint shaderProgram;

public:
	OGLGameObject(const string& name);
	virtual ~OGLGameObject();

	virtual void setShaderProgram(GLuint shaderProgram) {
		this->shaderProgram = shaderProgram;
	}
};

#endif

