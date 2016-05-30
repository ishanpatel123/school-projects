#include "GameObjectManager.h"
#include "GameObject.h"
#include "Player.h"

GameObjectManager::GameObjectManager()
{
}

GameObjectManager::~GameObjectManager()
{
	for (
		auto iterator = this->allObjects.begin(); 
			iterator != this->allObjects.end(); 
				iterator++) {
		delete iterator->second;
	}
}

void GameObjectManager::addObject(const string& name, GameObject* object)
{
	if (this->allObjects.find(name) == this->allObjects.end()) {
		this->allObjects[name] = object;
	}
}

GameObject* GameObjectManager::getObject(const string& name)
{
	if (this->allObjects.find(name) != this->allObjects.end()) {
		return this->allObjects[name];
	}
	return nullptr;
}

void GameObjectManager::updateVisibleObjects()
{
	this->visibleObjects.clear();
	auto iterator = this->allObjects.begin();
	while (iterator != this->allObjects.end()) {
		if (iterator->second->isVisible()) {
			this->visibleObjects[iterator->first] = iterator->second;
		}
		iterator++;
	}
}

void GameObjectManager::update(float elapsedSeconds)
{
	auto iterator = this->allObjects.begin();
	while (iterator != this->allObjects.end()) {
		iterator->second->update(elapsedSeconds);
		iterator++;
	}
}

void GameObjectManager::renderVisibleObjects()
{
	auto iterator = this->visibleObjects.begin();
	while (iterator != this->visibleObjects.end()) {
		iterator->second->render();
		iterator++;
	}
}

void GameObjectManager::clearCollisions()
{
	auto iterator = this->allObjects.begin();
	while (iterator != this->allObjects.end()) {
		iterator->second->clearCollisions();
		iterator++;
	}
	this->collidingObjects.clear();
	this->player->clearCollisions();
}

void GameObjectManager::checkForCollisions()
{
	// Brute force
	auto iterator = this->allObjects.begin();
	while (iterator != this->allObjects.end()) {
		auto iterator2 = this->allObjects.begin();
		while (iterator2 != this->allObjects.end()) {
			iterator->second->checkForCollision(iterator2->second);
			if (iterator->second->isColliding()) {
				this->collidingObjects[iterator->second->getName()] = iterator->second;
			}
			iterator2++;
		}
		this->player->checkForCollision(iterator->second);
		if (this->player->isColliding()) {
			this->collidingObjects[this->player->getName()] = this->player;
		}
		iterator++;
	}
}

void GameObjectManager::resolveCollisions()
{
	auto iterator = this->allObjects.begin();
	while (iterator != this->allObjects.end()) {
		iterator->second->resolveCollisions();
		iterator++;
	}
	this->player->resolveCollisions();
}
