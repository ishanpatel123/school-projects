#pragma once
#ifndef CAMERA
#define CAMERA

#include "GameObject.h"

#include <glm\glm.hpp>

class Player;

class Camera : public GameObject
{
protected:
	glm::vec3 up;

	glm::vec3 target;

	Player* player;

public:
	Camera();

	virtual ~Camera();

	virtual void setTarget(float x, float y, float z);

	virtual void setUp(float x, float y, float z);
	
	virtual void update(float elapsedSeconds) {}

	void render() {}

	virtual void setPlayer(Player* player);

	virtual Player* getPlayer() { return this->player; }

protected:
	virtual void updateOrientation();
};

#endif

