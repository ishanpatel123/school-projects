#pragma once
#ifndef GAME_OBJECT
#define GAME_OBJECT

#include "RGBA.h"

#include <string>
using std::string;

class IBehavior;
class Texture;

struct Material {
	float ambientIntensity; // Light emitted by this object
	RGBA specular; 
	float shininess; 
};

class GameObject
{
protected:
	string name;
	// Must be allocated on the heap, the first element stores
	// the size
	float * vertexData;
	// Must be allocated on the heap, the first element stores
	// the size
	short* indexData;

	bool visible;

	IBehavior* behavior;

	Texture* texture;

public:
	Material material;

public:
	GameObject(string name);

	virtual ~GameObject();

	void setVertexData(float * vertexData) { this->vertexData = vertexData; }

	float* getVertexData() { return this->vertexData; }

	void setIndexData(short* indexData) { this->indexData = indexData; }

	short* getIndexData() { return this->indexData; }
	
	string getName() const { return this->name; }

	void setTexture(Texture* texture) { this->texture = texture; }

	bool isTextured() { return this->texture != nullptr; }

	virtual void update(float elapsedSeconds);

	virtual void render() = 0;

	void setVisibility(bool visible) { this->visible = visible; }

	bool isVisible() const { return this->visible; }

	void setBehavior(IBehavior* behavior) { this->behavior = behavior; }
};

#endif

