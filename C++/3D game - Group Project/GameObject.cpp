#include "GameObject.h"
#include "IBehavior.h"
#include "OGLReferenceFrame.h"

GameObject::GameObject(string name)
{
	this->name = name;
	this->visible = false;
	this->behavior = nullptr;
	this->material.ambientIntensity = 0.1f; 
	this->material.specular = { 0.0f, 0.0f, 0.0f, 1.0f };
	this->material.shininess = 0.000001f;
	this->texture = nullptr;
	this->showBoundingBox = false;
	this->damping = 0.99f;
	this->fixedInPlace = true;
	this->ground = false;
	this->onGround = false;
}

void GameObject::update(float elapsedSeconds)
{
	if (!this->fixedInPlace) {
		// Linear movement only
		this->delta = this->velocity * elapsedSeconds;
		this->referenceFrame.move(this->delta);
		if (this->behavior) {
			this->behavior->update(elapsedSeconds);
		}
		this->velocity += this->acceleration * elapsedSeconds;
		this->velocity *= powf(this->damping, elapsedSeconds);
	}
	this->updateBoundingBox();
}

void GameObject::updateBoundingBox()
{
	this->boundingBox.referenceFrame = this->referenceFrame;
	this->boundingBox.applyTransform();
}

GameObject::~GameObject()
{
	if (this->behavior) {
		delete this->behavior;
	}
}

bool GameObject::checkForCollision(GameObject* otherObject)
{
	// Don't check the fixed objects
	if (!this->fixedInPlace) {
		// Can't collide with self
		if (this != otherObject) {
			if (!this->isCollidingWith(otherObject)) {
				if (this->boundingBox.overlapsWith(otherObject->boundingBox)) {
					this->objectsColliding[otherObject->getName()] = otherObject;
					otherObject->objectsColliding[this->getName()] = this;
					if (otherObject->isGround()) {
						this->onGround = true;
					}
					return true;
				}
			}
		}
	}
	return false;
}

bool GameObject::isCollidingWith(GameObject* otherObject)
{
	return this->objectsColliding.find(otherObject->getName()) != this->objectsColliding.end();
}

void GameObject::resolveCollisions()
{
	if (this->isColliding()) {
		// This needs to improve
		this->referenceFrame.move(-(this->delta * 0.25f));
		this->stopMoving();
	}
	else {
		if (!this->onGround && !this->fixedInPlace && !this->ground) {
			this->acceleration.y = -32.2f;
		}
	}
}
