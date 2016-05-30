#include "GameObject.h"
#include "IBehavior.h"

GameObject::GameObject(string name)
{
	this->name = name;
	this->vertexData = nullptr;
	this->visible = true;
	this->indexData = nullptr;
	this->behavior = nullptr;
	this->material.ambientIntensity = 0.1f; 
	this->material.specular = { 0.0f, 0.0f, 0.0f, 1.0f };
	this->material.shininess = 0.000001f;
	this->texture = nullptr;
}

void GameObject::update(float elapsedSeconds)
{
	if (this->behavior) {
		this->behavior->update(this, elapsedSeconds);
	}
}

GameObject::~GameObject()
{
	if (this->vertexData) {
		delete[] this->vertexData;
	}
	if (this->indexData) {
		delete[] this->indexData;
	}
	if (this->behavior) {
		delete this->behavior;
	}
}
