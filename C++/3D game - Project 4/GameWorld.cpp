#include <Windows.h>
#include "GameWorld.h"
#include "GameObjectManager.h"
#include "Camera.h"
#include "PCInputSystem.h"
#include "OGLFirstPersonCamera.h"
#include "LightSource.h"
#include "TheGame.h"

extern int turnLight, turnLight2, turnLight3, turnLight4, turnLight5;
GameWorld::GameWorld(
	GameObjectManager *objectManager, Camera *camera)
{
	this->objectManager = objectManager;
	this->camera = camera;
	this->inputSystem = NULL;
}

GameWorld::~GameWorld()
{
	delete this->objectManager;
	delete this->camera;
	for (size_t i = 0; i < this->localLights.size(); i++) {
		delete this->localLights[i];
	}
}

void GameWorld::update(float elapsedSeconds)
{
	for (size_t i = 0; i < this->localLights.size(); i++) {
		this->localLights[i]->update(elapsedSeconds);
	}

	//Turn light ON and OFF
	if (turnLight == 1)
	{
		localLights[0]->setPosition(0.0f, 10.5f, 0.0f);
		localLights[0]->setIntensity(1.2f);
	}
	else
	{
		localLights[0]->setPosition(0.0f, 15.0f, 0.0f);
		localLights[0]->setIntensity(0);
	}

	if (turnLight2 == 1)
	{
		localLights[1]->setPosition(10, 3, -13);
		localLights[1]->setIntensity(1.2f);
	}
	else
	{
		localLights[1]->setPosition(10, 15, -13);
		localLights[1]->setIntensity(0);
	}

	if (turnLight3 == 1)
	{
		localLights[2]->setPosition(10, 3, 13);
		localLights[2]->setIntensity(1.2f);
	}
	else
	{
		localLights[2]->setPosition(10, 15, 13);
		localLights[2]->setIntensity(0);
	}

	if (turnLight4 == 1)
	{
		localLights[3]->setPosition(-19, 10.5, 0);
		localLights[3]->setIntensity(1.2f);
	}
	else
	{
		localLights[3]->setPosition(-19, 15, 0);
		localLights[3]->setIntensity(0);
	}

	if (turnLight5 == 1)
	{
		localLights[4]->setPosition(-14.5, 5, -11);
		localLights[4]->setIntensity(1.2f);
	}
	else
	{
		localLights[4]->setPosition(-14.5, 15, -11);
		localLights[4]->setIntensity(0);
	}
	this->objectManager->update(elapsedSeconds);
	this->objectManager->updateVisibleObjects();
}

void GameWorld::processInputs()
{
	this->theGame->processInputs();
}
