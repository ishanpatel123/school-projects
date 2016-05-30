#include "car.h"
#include "Cuboid.h"
#include "Axis.h"
#include "Tire.h"

car::car(const string& name) : OGL3DCompositeObject(name)
{
	this->body = new Cuboid("body", 0.4f, 0.4f, 0.4f, { 0.9f, 0.9f, 0.9f, 1 });
	this->wings = new Cuboid("wings", 0.4f, 0.4f, 0.2f, { 0.9f, 0.9f, 0.9f, 1 });
	this->rotateDegrees = 0.0f;
	this->state = SWING_UP;
	this->tiree = NULL;
	this->tiree2 = NULL;
	this->tiree3 = NULL;
	this->tiree4 = NULL;
}

car::~car()
{
	delete this->body;
	delete this->wings;
	//delete this->tiree;
}

void car::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->body->setShaderProgram(this->shaderProgram);
	this->wings->setShaderProgram(this->shaderProgram);
}




void car::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);

	this->rotateDegrees += (300.0f * elapsedSeconds);
	if (this->rotateDegrees > 360.0f) {
		this->rotateDegrees = 0;
	}
}

void car::render()
{
	this->body->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->body->referenceFrame);
	//this->shoulder->setTexture(texture);
	this->frameStack.rotateY(-90);
	this->body->render();
	this->frameStack.push();
	{
		this->frameStack.translate(0.4, 0.3, 0);
		this->wings->referenceFrame = this->frameStack.top();
		this->wings->render();
		this->frameStack.push();
		{
			this->frameStack.translate(0, 0, 0.4);
			this->wings->referenceFrame = this->frameStack.top();
			this->wings->render();
			this->frameStack.push();
			{
				this->frameStack.translate(0, 0, -0.8);
				this->wings->referenceFrame = this->frameStack.top();
				this->wings->render();
				this->frameStack.push();
				{
					this->frameStack.translate(-0.8, -0.3, 0.4);
					this->body->referenceFrame = this->frameStack.top();
					this->body->render();
					this->frameStack.push();
					{
						this->frameStack.translate(0, 0.2, 0);
						this->body->referenceFrame = this->frameStack.top();
						this->body->render();
						this->frameStack.push();
						{
							this->frameStack.translate(-0.4, 0.1, 0);
							this->body->referenceFrame = this->frameStack.top();
							this->body->render();
							this->frameStack.push();
							{
								this->frameStack.translate(0, -0.3, 0);
								this->body->referenceFrame = this->frameStack.top();
								this->body->render();
								this->frameStack.push();
								{
									this->frameStack.translate(0, 0, -0.4);
									this->body->referenceFrame = this->frameStack.top();
									this->body->render();
									this->frameStack.push();
									{
										this->frameStack.translate(-0.4, 0, 0);
										this->body->referenceFrame = this->frameStack.top();
										this->body->render();
										this->frameStack.push();
										{
											this->frameStack.translate(-0.4, 0, 0);
											this->body->referenceFrame = this->frameStack.top();
											this->body->render();
											this->frameStack.push();
											{
												this->frameStack.translate(-0.4, 0, 0.4);
												this->body->referenceFrame = this->frameStack.top();
												this->body->render();
												this->frameStack.push();
												{
													this->frameStack.translate(0.4, 0, 0.4);
													this->body->referenceFrame = this->frameStack.top();
													this->body->render();
													this->frameStack.push();
													{
														this->frameStack.translate(0.4, 0, 0);
														this->body->referenceFrame = this->frameStack.top();
														this->body->render();
														this->frameStack.push();
														{
															this->frameStack.translate(0.4, 0, 0);
															this->body->referenceFrame = this->frameStack.top();
															this->body->render();
															this->frameStack.push();
															{
																this->frameStack.translate(-1.6, 0, 0);
																this->wings->referenceFrame = this->frameStack.top();
																this->wings->render();
																this->frameStack.push();
																{
																	this->frameStack.translate(0, 0, -0.4);
																	this->wings->referenceFrame = this->frameStack.top();
																	this->wings->render();
																	this->frameStack.push();
																	{
																		this->frameStack.translate(0, 0, -0.4);
																		this->wings->referenceFrame = this->frameStack.top();
																		this->wings->render();
																		if (this->tiree) {
																			this->frameStack.push();
																			{
																				//this->frameStack.rotateY(90.0f);
																				this->frameStack.translate(0.4, 0,-0.1);
																				this->frameStack.rotateZ(rotateDegrees);

																				this->tiree->referenceFrame = this->frameStack.top();
																				// The sword is rendered by the world.
																			}
																			this->frameStack.pop();
																		}
																		if (this->tiree2) {
																			this->frameStack.push();
																			{
																				this->frameStack.translate(0.4, 0, 0.8);
																				this->frameStack.rotateZ(rotateDegrees);

																				this->tiree2->referenceFrame = this->frameStack.top();
																				// The sword is rendered by the world.
																			}
																			this->frameStack.pop();
																		}
																		if (this->tiree3) {
																			this->frameStack.push();
																			{
																				this->frameStack.translate(2, 0, 0.8);
																				this->frameStack.rotateZ(rotateDegrees);

																				this->tiree3->referenceFrame = this->frameStack.top();
																				// The sword is rendered by the world.
																			}
																			this->frameStack.pop();
																		}
																		if (this->tiree4) {
																			this->frameStack.push();
																			{
																				this->frameStack.translate(2, 0, 0);
																				this->frameStack.rotateZ(rotateDegrees);

																				this->tiree4->referenceFrame = this->frameStack.top();
																				// The sword is rendered by the world.
																			}
																			this->frameStack.pop();
																		}
																	}
																	this->frameStack.pop();
																}
																this->frameStack.pop();
																}
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

void car::addTire(Tire* tire)
{
		this->tiree = tire;
		//this->tire->setShaderProgram(this->shaderProgram);
}
void car::addTire2(Tire* tire)
{
	//this->tire->setShaderProgram(this->shaderProgram);
	this->tiree2 = tire;
}
void car::addTire3(Tire* tire)
{
	//this->tire->setShaderProgram(this->shaderProgram);
	this->tiree3 = tire;
}

void car::addTire4(Tire* tire)
{
	//this->tire->setShaderProgram(this->shaderProgram);
	this->tiree4 = tire;
}