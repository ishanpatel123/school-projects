#include "TreasureChest.h"
#include "Texture.h"
#include "OGLTexturedFlatSurface.h"

TreasureChest::TreasureChest(const string& name, Texture* texture) : OGL3DCompositeObject(name)
{
	this->texture = texture;
	this->plane = new OGLTexturedFlatSurface("plane one", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane2 = new OGLTexturedFlatSurface("plane two", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane3 = new OGLTexturedFlatSurface("plane three", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane4 = new OGLTexturedFlatSurface("plane four", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane5 = new OGLTexturedFlatSurface("plane three", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane6 = new OGLTexturedFlatSurface("plane four", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane7 = new OGLTexturedFlatSurface("plane four", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane8 = new OGLTexturedFlatSurface("plane two", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane9 = new OGLTexturedFlatSurface("plane three", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane10 = new OGLTexturedFlatSurface("plane four", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane11 = new OGLTexturedFlatSurface("plane three", 2, 2, 1, 1, { 1, 1, 1, 1 });
	this->plane12 = new OGLTexturedFlatSurface("plane four", 2, 2, 1, 1, { 1, 1, 1, 1 });

}

TreasureChest::~TreasureChest()
{
	delete this->plane;
	delete this->plane2;
	delete this->plane3;
	delete this->plane4;
	delete this->plane5;
	delete this->plane6;
	delete this->plane7;
	delete this->plane8;
	delete this->plane9;
	delete this->plane10;
	delete this->plane11;
	delete this->plane12;
	
}


void TreasureChest::setShaderProgram(GLuint shaderProgram)
{
	this->shaderProgram = shaderProgram;
	this->plane->setShaderProgram(this->shaderProgram);
	this->plane2->setShaderProgram(this->shaderProgram);
	this->plane3->setShaderProgram(this->shaderProgram);
	this->plane4->setShaderProgram(this->shaderProgram);
	this->plane5->setShaderProgram(this->shaderProgram);
	this->plane6->setShaderProgram(this->shaderProgram);
	this->plane7->setShaderProgram(this->shaderProgram);
	this->plane8->setShaderProgram(this->shaderProgram);
	this->plane9->setShaderProgram(this->shaderProgram);
	this->plane10->setShaderProgram(this->shaderProgram);
	this->plane11->setShaderProgram(this->shaderProgram);
	this->plane12->setShaderProgram(this->shaderProgram);

}

void TreasureChest::update(float elapsedSeconds)
{
	OGL3DCompositeObject::update(elapsedSeconds);
}
void TreasureChest::render()
{
	this->plane->setTexture(this->texture);
	this->plane2->setTexture(this->texture);
	this->plane3->setTexture(this->texture);
	this->plane4->setTexture(this->texture);
	this->plane5->setTexture(this->texture);
	this->plane6->setTexture(this->texture);
	this->plane7->setTexture(this->texture);
	this->plane8->setTexture(this->texture);
	this->plane9->setTexture(this->texture);
	this->plane10->setTexture(this->texture);
	this->plane11->setTexture(this->texture);
	this->plane12->setTexture(this->texture);

	this->plane->referenceFrame = this->referenceFrame;
	this->frameStack.setBaseFrame(this->plane->referenceFrame);
	this->plane->render();
	this->frameStack.push();
	{
		this->frameStack.translate(1.0f, -1.0f, 0);
		//this->frameStack.rotateZ(90.0f);
		this->frameStack.rotateZ(270.0f);
		this->plane2->referenceFrame = this->frameStack.top();
		this->plane2->render();
		this->frameStack.push();
		{
			this->frameStack.translate(1.0f, -1.0f, 0);
			//this->frameStack.rotateZ(90.0f);
			this->frameStack.rotateZ(270.0f);
			this->plane3->referenceFrame = this->frameStack.top();
			this->plane3->render();
			this->frameStack.push();
			{
				this->frameStack.translate(1.0f, -1.0f, 0);
				//this->frameStack.rotateZ(90.0f);
				this->frameStack.rotateZ(270.0f);
				this->plane4->referenceFrame = this->frameStack.top();
				this->plane4->render();
				this->frameStack.push();
				{
					this->frameStack.translate(0, -1.0f, 1.0f);
					//this->frameStack.rotateZ(90.0f);
					this->frameStack.rotateX(90.0f);
					this->plane5->referenceFrame = this->frameStack.top();
					this->plane5->render();
					this->frameStack.push();
					{
						this->frameStack.translate(0, -2.0, 0);
						//this->frameStack.rotateZ(90.0f);
						this->frameStack.rotateX(180.0f);
						this->plane6->referenceFrame = this->frameStack.top();
						this->plane6->render();
						this->frameStack.push();
						{
							this->frameStack.translate(0, 7.0, 0);
							this->plane7->referenceFrame = this->frameStack.top();
							this->plane7->render();
							this->frameStack.push();
							{
								this->frameStack.translate(1.0f, -1.0f, 0);
								//this->frameStack.rotateZ(90.0f);
								this->frameStack.rotateZ(270.0f);
								this->plane8->referenceFrame = this->frameStack.top();
								this->plane8->render();
								this->frameStack.push();
								{
									this->frameStack.translate(1.0f, -1.0f, 0);
									//this->frameStack.rotateZ(90.0f);
									this->frameStack.rotateZ(270.0f);
									this->plane9->referenceFrame = this->frameStack.top();
									this->plane9->render();
									this->frameStack.push();
									{
										this->frameStack.translate(1.0f, -1.0f, 0);
										//this->frameStack.rotateZ(90.0f);
										this->frameStack.rotateZ(270.0f);
										this->plane10->referenceFrame = this->frameStack.top();
										this->plane10->render();
										this->frameStack.push();
										{
											this->frameStack.translate(0, -1.0f, 1.0f);
											//this->frameStack.rotateZ(90.0f);
											this->frameStack.rotateX(90.0f);
											this->plane11->referenceFrame = this->frameStack.top();
											this->plane11->render();
											this->frameStack.push();
											{
												this->frameStack.translate(0, -2.0, 0);
												//this->frameStack.rotateZ(90.0f);
												this->frameStack.rotateX(180.0f);
												this->plane12->referenceFrame = this->frameStack.top();
												this->plane12->render();
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
	}
}