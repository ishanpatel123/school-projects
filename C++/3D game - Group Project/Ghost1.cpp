#include "Ghost1.h"
#include "Cuboid.h"
#include "Axis.h"
#include "GhostObject.h"
#include "OGL2DTexture.h"
Ghost1::Ghost1(const string& name, OGL2DTexture* texture) : OGL3DCompositeObject(name)
{
	this->body = new GhostObject("body", 2, 0.15f, 1.0f, { 1,0,0,1 });
	this->body2 = new GhostObject("body2", 1.6f, 0.15f, 1.5f, { 1,0,0,1 });
	this->body3 = new GhostObject("body3", 1.3f, 0.15f, 1.5f, { 1,0,0,1 });
	this->body4 = new GhostObject("body4", 1.0f, 0.15f, 1.5f, { 1,0,0,1 });
	this->body5 = new GhostObject("body5", 0.6f, 0.15f, 1.1f, { 1,0,0,1 });
	this->body6 = new GhostObject("body6", 0.3f, 0.15f, 1.1f, { 1,0,0,1 });
	this->eyes = new GhostObject("eyes", 0.25f, 0.15f, 0.5f, { 1, 1, 1, 1 });
	this->pupil = new GhostObject("pupil", 0.18f,0.15f, 0.18f, { 0, 0, 0, 1 });
	this->texture = texture;
}

Ghost1::~Ghost1()
{
	delete this->body;
	delete this->body2;	
	delete this->body3;
	delete this->body4;
	delete this->body5;
	delete this->body6;
	delete this->eyes;
	delete this->pupil;

}

void Ghost1::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->body->setShaderProgram(this->shaderProgram);
	this->body2->setShaderProgram(this->shaderProgram);
	this->body3->setShaderProgram(this->shaderProgram);
	this->body4->setShaderProgram(this->shaderProgram);
	this->body5->setShaderProgram(this->shaderProgram);
	this->body6->setShaderProgram(this->shaderProgram);
	this->eyes->setShaderProgram(this->shaderProgram);
	this->pupil->setShaderProgram(this->shaderProgram);

}

void Ghost1::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
}

void Ghost1::render()
{
	this->body->setTexture(this->texture);
	this->body2->setTexture(this->texture);
	this->body3->setTexture(this->texture);
	this->body4->setTexture(this->texture);
	this->body5->setTexture(this->texture);
	this->body6->setTexture(this->texture);
	this->eyes->setTexture(this->texture);
	this->pupil->setTexture(this->texture);

	this->body->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->body->referenceFrame);
	this->body->render();
	this->frameStack.push();
	{
		this->frameStack.translate(0, 0.17f, 0);
		this->body2->referenceFrame = this->frameStack.top();
		this->body2->render();
		this->frameStack.push();
		{
			this->frameStack.translate(0, 0.14f, 0);
			this->body3->referenceFrame = this->frameStack.top();
			this->body3->render();
			this->frameStack.push();
			{
				this->frameStack.translate(0, 0.17f, 0);
				this->body4->referenceFrame = this->frameStack.top();
				this->body4->render();
				this->frameStack.push();
				{
					this->frameStack.translate(0, 0.37f, 0);
					this->body5->referenceFrame = this->frameStack.top();
					this->body5->render();
					this->frameStack.push();
					{
						this->frameStack.translate(0, -1.0f, 0);
						this->body5->referenceFrame = this->frameStack.top();
						this->body5->render();
						this->frameStack.push();
						{
							this->frameStack.translate(-0.7f, 0, 0);
							this->body5->referenceFrame = this->frameStack.top();
							this->body5->render();
							this->frameStack.push();
							{
								this->frameStack.translate(1.4f, 0, 0);
								this->body5->referenceFrame = this->frameStack.top();
								this->body5->render(); 
								this->frameStack.push();
								{
									this->frameStack.translate(0, -0.07f, 0);
									this->body6->referenceFrame = this->frameStack.top();
									this->body6->render();
									this->frameStack.push();
									{
										this->frameStack.translate(-0.7f, 0, 0);
										this->body6->referenceFrame = this->frameStack.top();
										this->body6->render();
										this->frameStack.push();
										{
											this->frameStack.translate(-0.7f, 0, 0);
											this->body6->referenceFrame = this->frameStack.top();
											this->body6->render();
											this->frameStack.push();
											{
												this->frameStack.translate(0.3f, 0.8f, -0.03f);
												this->eyes->referenceFrame = this->frameStack.top();
												this->eyes->render();
												this->frameStack.push();
												{
													this->frameStack.rotateZ(90);
													this->eyes->referenceFrame = this->frameStack.top();
													this->eyes->render();
													this->frameStack.push();
													{
														this->frameStack.rotateZ(-90);
														this->frameStack.translate(0.8f,0,0);
														this->eyes->referenceFrame = this->frameStack.top();
														this->eyes->render();
														this->frameStack.push();
														{
															this->frameStack.rotateZ(90);
															this->eyes->referenceFrame = this->frameStack.top();
															this->eyes->render();
															this->frameStack.push();
															{
																this->frameStack.rotateZ(-90);
																this->frameStack.translate(0, 0, -0.02f);
																this->pupil->referenceFrame = this->frameStack.top();
																this->pupil->render();
																this->frameStack.push();
																{
																	this->frameStack.translate(-0.8f, 0, 0);
																	this->pupil->referenceFrame = this->frameStack.top();
																	this->pupil->render();
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
