#include "Tire.h"
#include "Cuboid.h"
#include "Axis.h"
#include "Sword.h"

Tire::Tire(const string& name) : OGL3DCompositeObject(name)
{
	this->tire1 = new Cuboid("tire1", 0.4f, 0.4f, 0.4f, { 0, 0, 0, 1 });
	this->rotateDegrees = 0.0f;
}

Tire::~Tire()
{
	delete this->tire1;
}


void Tire::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->tire1->setShaderProgram(this->shaderProgram);
}


void Tire::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);

	this->rotateDegrees += (300.0f * elapsedSeconds);
	if (this->rotateDegrees > 360.0f) {
		this->rotateDegrees = 0;
	}
}

void Tire::render()
{
	this->tire1->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->tire1->referenceFrame);
	//this->shoulder->setTexture(texture);
	this->tire1->render();
}



//this->frameStack.push();
//{
//	this->frameStack.translate(0.4, 0, 0);
//	//this->frameStack.rotateZ(rotateDegrees);
//
//	this->tire1->referenceFrame = this->frameStack.top();
//	this->tire1->render();
//	this->frameStack.push();
//	{
//		this->frameStack.translate(0, 0, 0.8);
//		this->tire2->referenceFrame.rotateWorldY(rotateDegrees);
//		this->tire2->referenceFrame = this->frameStack.top();
//		this->tire2->render();
//		this->frameStack.push();
//		{
//			this->frameStack.translate(2, 0, 0);
//			this->tire3->referenceFrame = this->frameStack.top();
//			this->tire3->render();
//			this->frameStack.push();
//			{
//				this->frameStack.translate(0, 0, -0.8);
//				this->tire4->referenceFrame = this->frameStack.top();
//				this->tire4->render();
//			}
//			this->frameStack.pop();
//		}
//		this->frameStack.pop();
//	}
//	this->frameStack.pop();
//}