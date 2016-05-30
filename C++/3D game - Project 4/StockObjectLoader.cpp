#include "StockObjectLoader.h"
#include "OGL3DObject.h"
#include "ObjectGenerator.h"
#include "GameObjectManager.h"
#include "Cuboid.h"
#include "Turret.h"
#include "Axis.h"
#include "Arm.h"
#include "Sword.h"
#include "Sphere.h"
#include "OGL2DTexture.h"
#include "BMPTextureLoader.h"
#include "OGLTexturedFlatSurface.h"
#include "OGL2DTextDisplay.h"
#include "Lamp.h"
#include "TreasureChest.h"
#include "Tree.h"
#include "Sofa.h"
#include "TableFan.h"
#include "car.h"
#include "Tire.h"
#include "Bird.h"
#include <fstream>
#include <sstream>
#include <string>
#include <array>
#include <vector>
#include <algorithm>

#include <gl\glew.h>
#include <cstdlib>
#include <ctime>
using namespace std;


StockObjectLoader::StockObjectLoader()
{
	srand((unsigned int)time(NULL));
}

StockObjectLoader::~StockObjectLoader()
{
}

/*
Loads all the objects without textures to GameObjectManager
*/
GameObjectManager* StockObjectLoader::loadAllOBjects(GameObjectManager *gameObjectManager, int type, const string& name,
	float cube, float width, float height,
	unsigned int widthSegments, unsigned int depthSegments,
	float red, float green, float blue, float alpha, float rotateX, float rotateY, float rotateZ,
	float translateX, float translateY, float translateZ)
{
	OGLObject *object;
	if(type == 1)
	{ 
		object = new OGLTexturedFlatSurface(name, width, height, widthSegments, depthSegments, { red, green, blue, alpha });
	}
	else if (type == 2) {
		object = new Lamp(name);
	}
	else if (type == 3) {
		object = new Tree(name);
	}
	else if (type == 4) {
		object = new Sofa(name);
	}
	else if (type == 5) {
		object = new Sphere(name, width, (int) height, (int) widthSegments, { red, green, blue, alpha });
	}
	else if (type == 6) {
		object = new Cuboid(name, width, height, cube, {red, green, blue, alpha});
	}
	else if (type == 7) {
		object = new TableFan(name);
	}
	else if (type == 8) {
		object = new Bird(name);
	}
	object->referenceFrame.translate(translateX, translateY, translateZ);

	if (rotateX != 0) {
		object->referenceFrame.rotateX(rotateX);
	}
	if (rotateY != 0) {
		object->referenceFrame.rotateY(rotateY);
	}
	if (rotateZ != 0) {
		object->referenceFrame.rotateZ(rotateZ);
	}

	gameObjectManager->addObject(name, object);
	return gameObjectManager;
}

/*
Loads all the objects with textures to GameObjectManager
*/
GameObjectManager* StockObjectLoader::loadAllTextureOBjects(GameObjectManager *gameObjectManager, const string& name, const string& textureName,
	float width, float height,
	unsigned int widthSegments, unsigned int depthSegments,
	float red, float green, float blue, float alpha, float rotateX, float rotateY, float rotateZ,
	float translateX, float translateY, float translateZ)
{
	OGLObject *object;	
	BMPTextureLoader loader;
	loader.setFilePath(textureName);
	OGL2DTexture * texture = new OGL2DTexture(loader.load());
	texture->setTexelFormat(GL_BGR);
	texture->setTypeOfData(GL_UNSIGNED_BYTE);
	texture->create();


	object = new OGLTexturedFlatSurface(name, width, height, widthSegments, depthSegments, { red, green, blue, alpha });
	object->setTexture(texture);
	object->referenceFrame.translate(translateX, translateY, translateZ);
	if (rotateX != 0) {
		object->referenceFrame.rotateX(rotateX);
	}
	if (rotateY != 0) {
		object->referenceFrame.rotateY(rotateY);
	}
	if (rotateZ != 0) {
		object->referenceFrame.rotateZ(rotateZ);
	}
	gameObjectManager->addObject(name, object);
	return gameObjectManager;
}

void StockObjectLoader::loadObjects(GameObjectManager *gameObjectManager)
{
	BMPTextureLoader loader;
	
	OGLObject *object;
	
	//read the data from file and store in data[] array
	int i=0, j=0;
	float data[504];
	unsigned int data2[78];
	float type,  width,  height,  red,  green,  blue,  alpha,  rotX,  rotY,  rotZ,  transX,  transY,  transZ;
	unsigned int widthSeg, depthSeg;
	ifstream fin;
	fin.open("data.txt");
	string line;
	int changeShapeNum = 0;
	while (getline(fin, line))
	{
		istringstream   linestream(line);
		if (line.find("//") != -1) {
			changeShapeNum++;
			i = 0, j =0;
		}
		else {
			stringstream   linestream(line);
			if (changeShapeNum == 1)
			{
				linestream >> data[i];
				i++;
			}
			else if (changeShapeNum == 2)
			{
				linestream >> data2[j];
				j++;
			}
		}
	}
	i = 0,	j = 0;

	//Wall  objects
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Ground", type,width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Left Wall", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Right Wall Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Left Wall Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Back Wall", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "front Wall", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Right Wall", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
		
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 1, "Roof", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	//Lamp objects
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 2, "Lamp1", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 2, "Lamp2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 2, "Lamp3", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	//Tree objects
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 3, "Tree1", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
		
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 3, "Tree2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 3, "Tree3", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	//Sofa objects
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 4, "Sofa1", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 4, "Sofa2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
		
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 4, "Sofa3", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 4, "Sofa4", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 4, "Sofa5", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//bulb objects
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 5, "Sphere", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 5, "Sphere Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Table object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Table1", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Table2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Bed object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Bed1 Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Bed2 Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Pillow object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Pillow1 Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Pillow2 Room2", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//TV object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "TV", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Door object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "Door", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Door handle object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "DoorHandle", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Pictures object
	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "owlFamily", "owlFamily.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "owlFamily2", "owlFamily.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);
	
	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "owlBook", "owlBooks.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "owlCook", "owlCook.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "ROOM2", "ROOM2.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllTextureOBjects(gameObjectManager, "ROOM1", "ROOM1.bmp", width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Remote object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 6, "remote", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//TableFan Object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 7, "TableFan1", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Bird Object
	type = data[i++]; width = data[i++]; height = data[i++]; red = data[i++]; green = data[i++]; blue = data[i++]; alpha = data[i++];
	rotX = data[i++]; rotY = data[i++]; rotZ = data[i++]; transX = data[i++]; transY = data[i++]; transZ = data[i++];
	widthSeg = data2[j++]; depthSeg = data2[j++];
	gameObjectManager = loadAllOBjects(gameObjectManager, 8, "Bird", type, width, height, widthSeg, depthSeg, red, green, blue, alpha, rotX, rotY, rotZ, transX, transY, transZ);

	//Car Object
	transX = data[i++]; transY = data[i++]; transZ = data[i++];
	object = new car("car");
	object->referenceFrame.translate(transX, transY, transZ);
	gameObjectManager->addObject("car", object);

	//Applying tires to car
	car *arm = (car*)object;
	object = new Tire("tire1");
	gameObjectManager->addObject("tire1", object);
	arm->addTire((Tire*)object);

	object = new Tire("tire2");
	gameObjectManager->addObject("tire2", object);
	arm->addTire2((Tire*)object);

	object = new Tire("tire3");
	gameObjectManager->addObject("tire3", object);
	arm->addTire3((Tire*)object);

	object = new Tire("tire4");
	gameObjectManager->addObject("tire4", object);
	arm->addTire4((Tire*)object);
}





