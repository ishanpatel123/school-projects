#pragma once
#ifndef KEY
#define KEY

#include "OGL3DObject.h"
class Key :
	public OGL3DObject
{
public:
	Key(const string& name);
	virtual ~Key();

protected:
	void generate();
};

#endif