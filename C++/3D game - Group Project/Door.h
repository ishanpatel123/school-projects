#pragma once
#ifndef DOOR
#define DOOR

#include "Construct.h"

class Door : public Construct
{
public:
	enum DoorState { CLOSED, OPENING, CLOSING, OPEN};

protected:
	DoorState doorState;

	float openAngle;

public:
	Door(const string& name);

	virtual ~Door();

	void update(float elapsedSeconds);

	void setState(DoorState doorState) { this->doorState = doorState; }
};

#endif

