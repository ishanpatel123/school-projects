#include "TableFan.h"
#include "Texture.h"
#include "OGLTexturedFlatSurface.h"
#include "Cuboid.h"

TableFan::TableFan(const string& name) : OGL3DCompositeObject(name)
{
	this->base = new Cuboid("base", 1, 1, 0.1, { 1,1,1, 1 });
	this->leg1 = new Cuboid("leg1", 1, 1, 0.1, { 1,1,1, 1 });
	this->tower = new Cuboid("tower", 1, 1, 2, { 1,1,1, 1 });
	this->towerTop = new Cuboid("towerTop", 0.4, 0.4, 2, { 0.5f,0.5f,0.5f, 1 });
	this->nacelle = new Cuboid("nacelle", 1.4, 0.6, 0.6, { 1,1,1, 1 });
	this->fan1 = new Cuboid("fan1", 0.1, 0.7, 2, { 0.3f,0.3f,0.3f, 1 });
	this->rotateDegrees = 0.0f;
	this->state = left;
	this->nacelleDegrees = 0.0f;
}

TableFan::~TableFan()
{
	delete this->base;
	delete this->leg1;
	delete this->tower;
	delete this->towerTop;
	delete this->nacelle;
	delete this->fan1;
}


void TableFan::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->base->setShaderProgram(this->shaderProgram);
	this->leg1->setShaderProgram(this->shaderProgram);
	this->tower->setShaderProgram(this->shaderProgram);
	this->towerTop->setShaderProgram(this->shaderProgram);
	this->nacelle->setShaderProgram(this->shaderProgram);
	this->fan1->setShaderProgram(this->shaderProgram);
}

/*
Updating rotation of degree of nacelle and fan
*/
void TableFan::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
	this->rotateDegrees += (300.0f * elapsedSeconds);
		if (this->rotateDegrees > 360.0f) {
			this->rotateDegrees = 0;
		}
	switch (this->state) {
	case left:
		this->nacelleDegrees += (100.0f * elapsedSeconds);
		if (this->nacelleDegrees >120.0f) {
			this->state = right;
		}
		break;
	case right:
		this->nacelleDegrees -= (100.0f * elapsedSeconds);
		if (this->nacelleDegrees < 0.0f) {
			this->state = left;
		}
		break;
	}
}
void TableFan::render()
{
	this->base->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->base->referenceFrame);
	this->base->render();
	this->frameStack.push(); {
		this->frameStack.translate(-1, 0, 0);
		this->leg1->referenceFrame = this->frameStack.top();
		this->leg1->render();
		this->frameStack.push(); {
			this->frameStack.translate(2, 0, 0);
			this->leg1->referenceFrame = this->frameStack.top();
			this->leg1->render();
			this->frameStack.push(); {
				this->frameStack.translate(-1, 0, 1);
				this->leg1->referenceFrame = this->frameStack.top();
				this->leg1->render();
				this->frameStack.push(); {
					this->frameStack.translate(0, 0, -2);
					this->leg1->referenceFrame = this->frameStack.top();
					this->leg1->render();
					this->frameStack.push(); {
						this->frameStack.translate(0, 1, 1);
						this->tower->referenceFrame = this->frameStack.top();
						this->tower->render();
						this->frameStack.push(); {
							this->frameStack.translate(0, 1, 0);
							this->towerTop->referenceFrame = this->frameStack.top();
							this->towerTop->render();
						}
						this->frameStack.pop();
						this->frameStack.push(); {
							this->frameStack.rotateY(nacelleDegrees);
							this->frameStack.translate(0.2, 2, 0);
							this->nacelle->referenceFrame = this->frameStack.top();
							this->nacelle->render();
							this->frameStack.push(); {
								this->frameStack.rotateX(rotateDegrees);
								this->frameStack.translate(0.6, 1.5, 0);
								this->fan1->referenceFrame = this->frameStack.top();
								this->fan1->render();
								this->frameStack.push(); {
									this->frameStack.translate(0, -3, 0);
									this->fan1->referenceFrame = this->frameStack.top();
									this->fan1->render();
								}
								this->frameStack.pop();
								this->frameStack.push(); {
									this->frameStack.translate(0, -1.5, 1.5);
									this->frameStack.rotateX(90);
									this->fan1->referenceFrame = this->frameStack.top();
									this->fan1->render();
									this->frameStack.push(); {
										this->frameStack.translate(0, -3, 0);
										this->fan1->referenceFrame = this->frameStack.top();
										this->fan1->render();
									}
									this->frameStack.pop();
								}
								this->frameStack.pop();
							}
							this->frameStack.pop();
						}
						this->frameStack.pop();
					}
					this->frameStack.pop();
				}
				this->frameStack.pop();
			}
			this->frameStack.pop();
		}
		this->frameStack.pop();
	}
	this->frameStack.pop();
}