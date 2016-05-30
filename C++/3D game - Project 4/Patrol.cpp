#include "Patrol.h"
#include "OGLObject.h"



Patrol::Patrol(float maxDistance)
{
	this->state = MOVING_FORWARD;
	this->maxDistance = maxDistance;
	this->distanceMoved = 0;
	this->rotate180 = 0;

}


Patrol::~Patrol()
{
}

void Patrol::update(GameObject *object, float elapsedSeconds)
{
	OGLObject* obj = (OGLObject*)object;
	float delta = 10.0f * elapsedSeconds;
	this->distanceMoved += delta;

	switch (this->state) {
	case MOVING_BACKWARD:
		if(rotate180 >= 180.0f){
			this->state = MOVING_FORWARD;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
			rotate180 = 0;
		}
		obj->referenceFrame.rotateY(-10.0f);
		rotate180 += 10.0f;
		break;

	case MOVING_FORWARD:
		if (this->distanceMoved >= this->maxDistance) {
			this->state = MOVING_BACKWARD;
			delta = this->distanceMoved - this->maxDistance;
			this->distanceMoved = 0;
		}
		obj->referenceFrame.moveBackward(delta);
		break;
	
	}
}