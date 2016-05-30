#pragma once
#ifndef READ_CONFIGDATA
#define READ_CONFIGDATA

#include "string"
using std::string;

class readConfigData
{
public:
	struct ConfigData {
		string title;
		int positionX;
		int positionY;
		int width;
		int height;
		float backgroundRed;
		float backgroundGreen;
		float backgroundBlue;
		float backgroundAlpha;
		float secondBackgroundRed;
		float secondBackgroundGreen;
		float secondBackgroundBlue;
		float secondBackgroundAlpha;
	};

	void readConfigFile(string, ConfigData&);
};

#endif

