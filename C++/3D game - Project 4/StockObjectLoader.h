#pragma once
#ifndef STOCK_OBJECT_LOADER
#define STOCK_OBJECT_LOADER

#include "ObjectLoader.h"

#include <string>
using std::string;
class StockObjectLoader :
	public ObjectLoader
{
public:
	StockObjectLoader();
	~StockObjectLoader();
	GameObjectManager* loadAllOBjects(GameObjectManager * gameObjectManager, int type, const string& name,
		float cube, float width, float height,
		unsigned int numberOfWidthSegments, unsigned int numberOfDepthSegments,
		float red, float green, float blue, float alpha, float rotateX, float rotateY, float rotateZ,
		float translateX, float translateY, float translateZ);
	GameObjectManager* loadAllTextureOBjects(GameObjectManager * gameObjectManager, const string& name, const string& textureName,
		float width, float height,
		unsigned int numberOfWidthSegments, unsigned int numberOfDepthSegments,
		float red, float green, float blue, float alpha, float rotateX, float rotateY, float rotateZ,
		float translateX, float translateY, float translateZ);
	void loadObjects(GameObjectManager *gameObjectManager);
};

#endif

