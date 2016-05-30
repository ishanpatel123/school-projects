#pragma once
#ifndef GHOST_OBJECT
#define GHOST_OBJECT

#include "OGL3DObject.h"
#include "BaseCuboid.h"

class GhostObject : public BaseCuboid
{
public:
	GhostObject(const string& name, float width = 1, float depth = 1, float height = 1, RGBA faceColor = { 1, 1, 1, 1 });

	virtual ~GhostObject();

protected:
	void generate();
};

#endif
