#pragma once
#ifndef TREASURE_CHEST
#define TREASURE_CHEST

#include "OGL3DCompositeObject.h"

#include <string>
	using std::string;

class Texture;
class OGLTexturedFlatSurface;

class TreasureChest :
	public OGL3DCompositeObject
{

protected:
	OGLTexturedFlatSurface *plane;
	OGLTexturedFlatSurface *plane2;
	OGLTexturedFlatSurface *plane3;
	OGLTexturedFlatSurface *plane4;
	OGLTexturedFlatSurface *plane5;
	OGLTexturedFlatSurface *plane6;
	OGLTexturedFlatSurface *plane7;
	OGLTexturedFlatSurface *plane8;
	OGLTexturedFlatSurface *plane9;
	OGLTexturedFlatSurface *plane10;
	OGLTexturedFlatSurface *plane11;
	OGLTexturedFlatSurface *plane12;
	Texture *texture;


public:
	TreasureChest(const string& name, Texture* texture);
	virtual ~TreasureChest();
	void setShaderProgram(GLuint shaderProgram);
	void update(float elapsedSeconds);
	void render();

};

#endif


