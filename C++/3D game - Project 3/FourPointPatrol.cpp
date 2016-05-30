#include "FourPointPatrol.h"
#include "OGLObject.h"



FourPointPatrol::FourPointPatrol(float maxDistance)
{
	this->state = MOVING_FORWARD;
	this->maxDistance = maxDistance;
	this->distanceMoved = 0;
	this->rotate180 = 0;
}


FourPointPatrol::~FourPointPatrol()
{
}

//This behavior moves object forward -> left -> Right -> Backward
//When it reachs point, it rotate 90 degrees and keep changes the states
void FourPointPatrol::update(GameObject *object, float elapsedSeconds)
{
	OGLObject* obj = (OGLObject*)object;
	float delta = 10.0f * elapsedSeconds;
	this->distanceMoved += delta;

	switch (this->state) {
	case MOVING_FORWARD:
		if (this->distanceMoved >= this->maxDistance) {
			changeState = 0;
			this->state = ROTATE;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
		}
		obj->referenceFrame.moveBackward(delta);
		break;
	case ROTATE:
		if (rotate180 >= 90.0f) {
			if (changeState == 0) { this->state = MOVING_FORWARD; }
			else if (changeState == 1) { this->state = MOVING_LEFT; }
			else if (changeState == 2) { this->state = MOVING_RIGHT; }
			else if (changeState == 3) { this->state = MOVING_BACKWARD; }
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
			rotate180 = 0;
		}
		obj->referenceFrame.rotateY(15.0f);
		rotate180 += 15.0f;
		break;

	case MOVING_LEFT:
		if (this->distanceMoved >= this->maxDistance) {
			changeState = 1;
			this->state = ROTATE;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
		}
		obj->referenceFrame.moveBackward(delta);
		break;
	case MOVING_RIGHT:
		if (this->distanceMoved >= this->maxDistance) {
			changeState = 2;
			this->state = ROTATE;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
		}
		obj->referenceFrame.moveBackward(delta);
		break;

	case MOVING_BACKWARD:
		if (this->distanceMoved >= this->maxDistance) {
			changeState = 3;
			this->state = ROTATE;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
		}
		obj->referenceFrame.moveBackward(delta);
		break;

	}
}
