#include "Sofa.h"
#include "Texture.h"
#include "OGLTexturedFlatSurface.h"
#include "Cuboid.h"
Sofa::Sofa(const string& name) : OGL3DCompositeObject(name)
{
	this->back = new Cuboid("back", 1, 9, 4, { 0, 0.8f, 0.8f, 1 });
	this->seat = new Cuboid("seat", 4, 9, 1.7f, { 0, 0.8f, 0.8f, 1 });
	this->armTopLeft = new Cuboid("armTopLeft", 3, 0.5, 2.0f, { 0, 0.8f, 0.8f, 1 });
	this->armTopRight = new Cuboid("armTopRight", 3, 0.5, 2.0f, {0, 0.8f, 0.8f, 1 });

}

Sofa::~Sofa()
{
	delete this->back;
	delete this->seat;
	delete this->armTopLeft;
	delete this->armTopRight;

}


void Sofa::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->back->setShaderProgram(this->shaderProgram);
	this->seat->setShaderProgram(this->shaderProgram);
	this->armTopLeft->setShaderProgram(this->shaderProgram);	
	this->armTopRight->setShaderProgram(this->shaderProgram);

}

void Sofa::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
}
void Sofa::render()
{
	this->back->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->back->referenceFrame);
	this->back->render();
	this->frameStack.push(); {
		this->frameStack.translate(-1.5f, -1.3f, 0);
		this->seat->referenceFrame = this->frameStack.top();
		this->seat->render();
		this->frameStack.push(); {
			this->frameStack.translate(-0.5, 0.7, 4.25f);
			this->armTopLeft->referenceFrame = this->frameStack.top();
			this->armTopLeft->render();
			this->frameStack.push(); {
				this->frameStack.translate(0, 0, -8.5);
				this->armTopRight->referenceFrame = this->frameStack.top();
				this->armTopRight->render();
			}
			this->frameStack.pop();
		}
		this->frameStack.pop();
	}
	this->frameStack.pop();
}