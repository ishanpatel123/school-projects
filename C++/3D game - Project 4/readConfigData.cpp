#include "readConfigData.h"
#include "fstream"
#include "sstream"
#include "string"

using namespace std;

/*
Reads the config data from the texfile and stores it in ConfigData struct
*/
void readConfigData::readConfigFile(string fileName, ConfigData& config)
{
	string line;
	std::ifstream fin;
	fin.open("config.txt");
	while (!fin.eof()) {
		getline(fin, line);
		std::istringstream readLine;
		readLine.str(line.substr(line.find(":") + 1));

		if (line.find("title") != -1) {
			int lenth = line.size();
			int index = line.find_first_of(":", 0);
			string title = line.substr(index + 2, lenth);
			config.title = title;
		}
		else if (line.find("initial position x") != -1) {
			readLine >> config.positionX;
		}
		else if (line.find("initial position y") != -1) {
			readLine >> config.positionY;
		}
		else if (line.find("width") != -1) {
			readLine >> config.width;
		}
		else if (line.find("height") != -1) {
			readLine >> config.height;
		}
		else if (line.find("first background red") != -1) {
			readLine >> config.backgroundRed;
		}
		else if (line.find("first background green") != -1) {
			readLine >> config.backgroundGreen;
		}
		else if (line.find("first background blue") != -1) {
			readLine >> config.backgroundBlue;
		}
		else if (line.find("first background alpha") != -1) {
			readLine >> config.backgroundAlpha;
		}
	}
	fin.close();
}