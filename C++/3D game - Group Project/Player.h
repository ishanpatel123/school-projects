#pragma once
#ifndef PLAYER
#define PLAYER

#include "GameObject.h"

#include <string>
using std::string;

class Camera;

class Player :	public GameObject
{
protected:
	Camera* camera;

public:
	Player(const string& name);

	virtual ~Player();

	void update(float elapsedSeconds);

	void render();

	virtual void setCamera(Camera* camera); 

	virtual Camera* getCamera() { return this->camera; }

};

#endif

