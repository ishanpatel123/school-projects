#pragma once
#ifndef THE_GAME
#define THE_GAME

#include "BaseObject.h"

#include <string>
using std::string;
#include <vector>
using std::vector;

class GameEngine;
class AssetLoader;

class TheGame : public BaseObject
{
protected:
	struct DATAFILE {
		int type;
		string name;
		float width, depth, height, x, y, z, rotateY, red, green, blue, alpha;
	};

public:
	GameEngine *gameEngine;
	DATAFILE data[25];
public:
	TheGame();

	virtual ~TheGame();

	void loadShaders(const string& shaderAssetFilename);

	void setupGraphicsParameters(const string& uniformAssetFilename);

	void setupViewingEnvironment();

	void sendShaderData();

	void update(float elapsedSeconds);

	void Objects(int type, const string& name, float width, float depth, float height, float x, float y, float z, float rotateY, float red, float green, float blue, float alpha);

	void setup(const string& gameAssetFilename);

	void updateTextDisplay();

	void processInputs();

	void ReadData();

};

#endif

