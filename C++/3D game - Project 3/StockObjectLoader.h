#pragma once
#ifndef STOCK_OBJECT_LOADER
#define STOCK_OBJECT_LOADER

#include "ObjectLoader.h"
#include <gl/glew.h>

class StockObjectLoader :
	public ObjectLoader
{
protected:
	struct Vertex {
		GLfloat x;
	};
//	float * data;
public:
	StockObjectLoader();
	~StockObjectLoader();

	void loadObjects(GameObjectManager *gameObjectManager);
};

#endif

