#include "Door.h"

Door::Door(const string& name) : Construct(name)
{
	this->doorState = CLOSED;
	this->openAngle = 0;
}

Door::~Door()
{
}

void Door::update(float elapsedSeconds)
{
	float delta = 90 * elapsedSeconds;
	Construct::update(elapsedSeconds);
	switch (this->doorState) {
	case OPENING:
		this->openAngle += delta;
		if (this->openAngle > 90.0f) {
			this->doorState = CLOSING;
			delta = this->openAngle - 90.0f;
			this->openAngle = 90.0f;
		}
		this->referenceFrame.translate(2, 0, 0);
		this->referenceFrame.rotateY(delta);
		this->referenceFrame.translate(-2, 0, 0);
		break;
	case CLOSING:
		this->openAngle -= delta;
		if (this->openAngle < 0.0f) {
			this->doorState = OPENING;
			delta = this->openAngle;
			this->openAngle = 0.0f;
		}
		this->referenceFrame.translate(2, 0, 0);
		this->referenceFrame.rotateY(-delta);
		this->referenceFrame.translate(-2, 0, 0);
		break;
	}
}
