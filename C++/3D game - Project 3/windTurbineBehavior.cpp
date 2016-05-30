#include "windTurbineBehavior.h"
#include "OGLObject.h"

windTurbineBehavior::windTurbineBehavior(float maxDistance)
{
	this->state = START;
	this->maxDistance = maxDistance;
	this->distanceMoved = 0;
	this->rotate360 = 0;
	this->delta = 0;
	this->delta1 = 0;
}

windTurbineBehavior::~windTurbineBehavior()
{
}

//rotating the fan till the rotate360 = 50, 
//	then slow down rotation till rotate360 = 50, then repeat
void windTurbineBehavior::update(GameObject *object, float elapsedSeconds)
{
	OGLObject* obj = (OGLObject*)object;
	switch (this->state) {
	case START:
		this->delta1 += 0.5f;

		if (rotate360 >= 50.0f) {
			this->state = STOP;
			rotate360 = 0;
		}
		obj->referenceFrame.rotateY(this->delta1);
		rotate360 += 5.0f;
		break;

	case STOP:
		if (this->delta1 >= 0.0f) {
			this->delta1 -= 0.1f;
			this->state = START;
		}
		break;
	
	}
}

		