#include "Tree.h"
#include "Texture.h"
#include "OGLTexturedFlatSurface.h"
#include "Cuboid.h"
Tree::Tree(const string& name) : OGL3DCompositeObject(name)
{
	this->leaves1 = new Cuboid("leaves1", 1, 1, 1, { 0,1,0,1 });
	this->leaves2 = new Cuboid("leaves2", 1.5f, 1.5f, 1.2f, { 0,1,0,1 });
	this->leaves3 = new Cuboid("leaves3", 2, 2, 1.2f, { 0,1,0,1 });
	this->trunk = new Cuboid("trunk", 0.3f, 0.3f, 2, { 0.8f,0.4f,0,1 });
	this->treePot = new Cuboid("treePot", 1.2f, 1.2f, 1.0f, { 0.6f,0.2f,0,1 });
}

Tree::~Tree()
{
	delete this->leaves1;
	delete this->leaves2;
	delete this->leaves3;
	delete this->trunk;
	delete this->treePot;
}


void Tree::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->leaves1->setShaderProgram(this->shaderProgram);
	this->leaves2->setShaderProgram(this->shaderProgram);
	this->leaves3->setShaderProgram(this->shaderProgram);
	this->trunk->setShaderProgram(this->shaderProgram);
	this->treePot->setShaderProgram(this->shaderProgram);
}


void Tree::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
}
void Tree::render()
{
	this->leaves1->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->leaves1->referenceFrame);
	this->leaves1->render();
	this->frameStack.push(); {
		this->frameStack.translate(0, -1, 0);
		this->leaves2->referenceFrame = this->frameStack.top();
		this->leaves2->render();
		this->frameStack.push(); {
			this->frameStack.translate(0, -1.2f, 0);
			this->leaves3->referenceFrame = this->frameStack.top();
			this->leaves3->render();
			this->frameStack.push(); {
				this->frameStack.translate(0, -1.2f, 0);
				this->trunk->referenceFrame = this->frameStack.top();
				this->trunk->render();
				this->frameStack.push(); {
					this->frameStack.translate(0, -1.0f, 0);
					this->treePot->referenceFrame = this->frameStack.top();
					this->treePot->render();
				}
				this->frameStack.pop();
			}
			this->frameStack.pop();
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
