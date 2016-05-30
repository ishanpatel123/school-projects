#include "FirstPersonPlayer.h"
#include "OGLFirstPersonCamera.h"

FirstPersonPlayer::FirstPersonPlayer(const string& name)
	:Player(name)
{
}

FirstPersonPlayer::~FirstPersonPlayer()
{
}

void FirstPersonPlayer::resolveCollisions()
{
	if (this->isColliding()) {
		bool collidingWithOther = false;
		auto it = this->objectsColliding.begin();
		while (it != this->objectsColliding.end()) {
			if (!it->second->isGround()) {
				collidingWithOther = true;
				break;
			}
			it++;
		}
		if (collidingWithOther) {
			OGLFirstPersonCamera* camera = (OGLFirstPersonCamera*)this->camera;
			glm::vec3 delta = this->camera->getDelta();
			glm::vec3 position = this->camera->getPosition();
			position += -(delta);
			this->camera->setPosition(position);
			camera->setNotMoving();
			this->setPosition(position);
			this->updateBoundingBox();
		}
	}
	else {
		if (!this->onGround && !this->fixedInPlace && !this->ground) {
			this->camera->setAcceleration(glm::vec3(0, -32.2f, 0));
		}
	}
}
