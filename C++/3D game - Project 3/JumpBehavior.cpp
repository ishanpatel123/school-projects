#include "JumpBehavior.h"
#include "OGLObject.h"

JumpBehavior::JumpBehavior(float maxDistance)
{
	this->state = MOVING_UP;
	this->maxDistance = maxDistance;
	this->distanceMoved = 0;
	this->upDown = 0;

}

JumpBehavior::~JumpBehavior()
{
}

//MOVING_UP moves the character on +y axis, till upDown >= 30. If true, change state to MOVING_DOWN
// MOVING_DOWN moves the character on -y axis, till upDown >= 30. If true, change state to MOVING_UP
void JumpBehavior::update(GameObject *object, float elapsedSeconds)
{
	OGLObject* obj = (OGLObject*)object;
	glm::vec3 position;
	float delta = 19.0f * elapsedSeconds;

	switch (this->state) {
	case MOVING_UP:
		if (upDown >= 30.0f) {
			this->state = MOVING_DOWN;
			this->upDown = 0;
		}
		upDown += 5.0f;
		position = glm::vec3(0.0, 1.0f, 0.0);

		obj->referenceFrame.move(position, delta);
		break;
	case MOVING_DOWN:
		if (upDown >= 30.0f) {
			this->state = MOVING_UP;
			this->upDown = 0;
		}
		upDown += 5.0f;
		position = glm::vec3(0.0, -1.0f, 0.0);

		obj->referenceFrame.move(position, delta);
		break;
	}
}
