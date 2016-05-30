#include "Lamp.h"
#include "Texture.h"
#include "OGLTexturedFlatSurface.h"
#include "Cuboid.h"
Lamp::Lamp(const string& name) : OGL3DCompositeObject(name)
{
	this->shade = new Cuboid("shade", 2, 2, 2, { 0.8f, 0, 0.4f, 1 });
	this->tube = new Cuboid("tube", 0.2f, 0.2f, 4, { 1, 1, 1, 1 });
	this->base = new Cuboid("tube", 1, 1, 0.3f, { 1, 1, 1, 1 });
}

Lamp::~Lamp()
{
	delete this->shade;
	delete this->tube;
	delete this->base;
}


void Lamp::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->shade->setShaderProgram(this->shaderProgram);
	this->tube->setShaderProgram(this->shaderProgram);
	this->base->setShaderProgram(this->shaderProgram);
}

void Lamp::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
}
void Lamp::render()
{
	this->shade->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->shade->referenceFrame);
	this->shade->render();
	this->frameStack.push(); {
		this->frameStack.translate(0, -3, 0);
		this->tube->referenceFrame = this->frameStack.top();
		this->tube->render();
		this->frameStack.push(); {
			this->frameStack.translate(0, -1.8, 0);
			this->base->referenceFrame = this->frameStack.top();
			this->base->render();
		}
		this->frameStack.pop();
	}
	this->frameStack.pop();
	//this->frameStack.push();
	//{
	//	this->frameStack.translate(1.0f, -1.0f, 0);
	//	//this->frameStack.rotateZ(90.0f);
	//	this->frameStack.rotateZ(270.0f);
	//	this->plane2->referenceFrame = this->frameStack.top();
	//	this->plane2->render();
	//	this->frameStack.push();
	//	{
	//		this->frameStack.translate(1.0f, -1.0f, 0);
	//		//this->frameStack.rotateZ(90.0f);
	//		this->frameStack.rotateZ(270.0f);
	//		this->plane3->referenceFrame = this->frameStack.top();
	//		this->plane3->render();
	//		this->frameStack.push();
	//		{
	//			this->frameStack.translate(1.0f, -1.0f, 0);
	//			//this->frameStack.rotateZ(90.0f);
	//			this->frameStack.rotateZ(270.0f);
	//			this->plane4->referenceFrame = this->frameStack.top();
	//			this->plane4->render();
	//			this->frameStack.push();
	//			{
	//				this->frameStack.translate(0, -1.0f, 1.0f);
	//				//this->frameStack.rotateZ(90.0f);
	//				this->frameStack.rotateX(90.0f);
	//				this->plane5->referenceFrame = this->frameStack.top();
	//				this->plane5->render();
	//				this->frameStack.push();
	//				{
	//					this->frameStack.translate(0, -2.0, 0);
	//					//this->frameStack.rotateZ(90.0f);
	//					this->frameStack.rotateX(180.0f);
	//					this->plane6->referenceFrame = this->frameStack.top();
	//					this->plane6->render();
	//				}
	//				this->frameStack.pop();
	//			}
	//			this->frameStack.pop();
	//		}
	//		this->frameStack.pop();
	//	}
	//	this->frameStack.pop();
	//}
	//this->frameStack.pop();
}