#include "Bird.h"
#include "Cuboid.h"
#include "Axis.h"
#include "Tire.h"

Bird::Bird(const string& name) : OGL3DCompositeObject(name)
{
	this->body = new Cuboid("body", 0.4f, 0.8f, 0.4f, { 0.6f,0.2f,0,1 });
	this->head = new Cuboid("head", 0.4f, 0.4f, 0.4f, { 0.6f,0.2f,0,1 });
	this->nose = new Cuboid("nose", 0.3f, 0.15f, 0.15f, {1, 1, 0, 1 });
	this->legs = new Cuboid("legs", 0.12f, 0.12f, 0.4f, { 1, 1, 0, 1 });
	this->tail = new Cuboid("tail", 0.4f, 0.3f, 0.1f, { 0.6f,0.2f,0,1 });
	this->eyes = new Cuboid("eyes", 0.12f, 0.12f, 0.12f, { 0, 0, 0, 1 });
	this->wings = new Cuboid("wings", 0.4f, 0.7f, 0.1f, { 0.6f,0.2f,0,1 });
	this->angleY = 0;
	this->angleZ = 0;
	this->speedZ = 80;
}

Bird::~Bird()
{
	delete this->body;
	delete this->eyes;
	delete this->nose;
	delete this->legs;
	delete this->tail;
	delete this->head;
	delete this->wings;
}

void Bird::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->body->setShaderProgram(this->shaderProgram);
	this->eyes->setShaderProgram(this->shaderProgram);
	this->nose->setShaderProgram(this->shaderProgram);
	this->tail->setShaderProgram(this->shaderProgram);
	this->head->setShaderProgram(this->shaderProgram);
	this->wings->setShaderProgram(this->shaderProgram);
	this->legs->setShaderProgram(this->shaderProgram);

}

void Bird::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
	this->angleY += (30 * elapsedSeconds);
	if (this->angleY > 360) this->angleY -= 360;
	this->angleZ += (this->speedZ * elapsedSeconds)*2;
	if (this->angleZ > 25) {
		this->speedZ = -80;
	}
	else if (angleZ < -25) {
		this->speedZ = 80;
	}
}

void Bird::render()
{
	this->body->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->body->referenceFrame);
	this->frameStack.rotateY(-90);
	this->body->render();
	this->frameStack.push();
	{
		this->frameStack.translate(-0.4, 0.4, 0);
		this->head->referenceFrame = this->frameStack.top();
		this->head->render();
		this->frameStack.push();
		{
			this->frameStack.translate(-0.3, -0.07, 0);
			this->nose->referenceFrame = this->frameStack.top();
			this->nose->render();
			this->frameStack.push();
			{
				this->frameStack.translate(0.15, 0.15, 0.12);
				this->eyes->referenceFrame = this->frameStack.top();
				this->eyes->render();
				this->frameStack.push();
				{
					this->frameStack.translate(0, 0, -0.23);
					this->eyes->referenceFrame = this->frameStack.top();
					this->eyes->render();
					this->frameStack.push();
					{
						this->frameStack.translate(0.5, -0.7, 0);
						this->frameStack.rotateZ(30);

						this->legs->referenceFrame = this->frameStack.top();
						this->legs->render();
						this->frameStack.push();
						{
							this->frameStack.translate(0, 0, 0.2);
							this->legs->referenceFrame = this->frameStack.top();
							this->legs->render();
							this->frameStack.push();
							{
								this->frameStack.translate(0.7, 0.05, -0.1);
								this->tail->referenceFrame = this->frameStack.top();
								this->tail->render();
								this->frameStack.push();
								{
									this->frameStack.rotateZ(-20);
									this->frameStack.translate(-0.55, 0.1, -0.65);
									this->frameStack.rotateZ(angleZ);

									this->wings->referenceFrame = this->frameStack.top();
									this->wings->render();
									this->frameStack.push();
									{
										this->frameStack.rotateZ(180);
										this->frameStack.translate(0, 0, 1.3);

										this->wings->referenceFrame = this->frameStack.top();
										this->wings->render();
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
