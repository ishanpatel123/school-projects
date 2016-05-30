#include "StockObjectLoader.h"
#include "OGL3DObject.h"
#include "ObjectGenerator.h"
#include "GameObjectManager.h"

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
int objData[145];

void StockObjectLoader::loadObjects(GameObjectManager *gameObjectManager)
{
	//opening and reading data.txt
	float fileData[189];
	//Holds the local variables from fileData array before accessing them as parameters
	float width, depth, height, red, green, blue, alpha, num1, num2, num3, x, y, z;
	ifstream fin;
	fin.open("data.txt");
	string line;
	int i = 0, changeShapeNum = 0;
	//reads the line
	while (getline(fin, line))
	{
		istringstream   linestream(line);
		//detects line if "//" found, and increase changeShapeNum
		if (line.find("//") != -1) {
			changeShapeNum++;
			i = 0;
			if (line.find("//objectData") != -1) {
				objData[0] = 36;
				i = 1;
			}

		}
		else {
			stringstream   linestream(line);
			if (changeShapeNum == 1)
			{
				//stroing all values from file to fileData array
				linestream >> fileData[i];
				i++;
			}
			if (changeShapeNum == 2)
			{
				//stroing all values from file to objData array
				linestream >> objData[i];
				i++;
			}
		}
	}

	//Creating objects using the vertex data stored in ObjectGenerator.cpp
	OGLObject *object;
	VBOObject* vboObject;
	i = 0;
	object = new OGL3DObject("Axes");
	object->setIndexedArrayType();
	ElementArray arr = ObjectGenerator::generateRightHandedAxesIndexedArray(5);
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"Axes", arr.vertexData, arr.indexData, GL_LINES);
	object->addVBOObject(vboObject);
	gameObjectManager->addObject("Axes", object);

	object = new OGL3DObject("Surface");
	width = fileData[i++];	depth = fileData[i++];
	object->setVertexData(ObjectGenerator::generateXZSurface(width, depth));
	vboObject = OGLObject::createVBOObject(
		"triangles", object->getVertexData(), GL_TRIANGLES);
	object->addVBOObject(vboObject);
	gameObjectManager->addObject("Surface", object);


	//Wind turbine object
	object = new OGL3DObject("windTurbine");
	object->setIndexedArrayType();
	//Note -	Stroing data to local variables before using data as parameter
	//			If direct use of data as parameters, it changes the output
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray2(width, depth, height, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData); object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("windTurbine", object);


	object = new OGL3DObject("standForWindTurbine");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray(width, depth, height, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData); object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("standForWindTurbine", object);

	object = new OGL3DObject("Fan");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray(width, depth, height, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData); object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Fan", object);


	//Character object
	object = new OGL3DObject("Character1");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character1", object);

	object = new OGL3DObject("Character2");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character2", object);

	object = new OGL3DObject("Character3");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character3", object);

	object = new OGL3DObject("Character4");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character4", object);

	object = new OGL3DObject("Character5");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character5", object);

	object = new OGL3DObject("Character6");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character6", object);

	object = new OGL3DObject("Character7");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character7", object);

	object = new OGL3DObject("Character8");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Character8", object);


	//Car Object
	object = new OGL3DObject("Car1");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Car1", object);

	object = new OGL3DObject("Car2");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Car2", object);

	object = new OGL3DObject("Car3");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++]; num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Car3", object);

	object = new OGL3DObject("Car4");
	object->setIndexedArrayType();
	width = fileData[i++];	depth = fileData[i++];	height = fileData[i++];
	num1 = fileData[i++];	num2 = fileData[i++];	num3 = fileData[i++];
	red = fileData[i++];	green = fileData[i++];	blue = fileData[i++];	alpha = fileData[i++];
	arr = ObjectGenerator::generateBoxIndexedArray3(width, depth, height, num1, num2, num3, { red, green, blue, alpha });
	object->setVertexData(arr.vertexData);
	object->setIndexData(arr.indexData);
	vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	object->addVBOObject(vboObject);
	x = fileData[i++];	y = fileData[i++];	z = fileData[i++];
	object->referenceFrame.setPosition(x, y, z);
	gameObjectManager->addObject("Car4", object);

}
