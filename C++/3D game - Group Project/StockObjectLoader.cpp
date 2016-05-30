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
#include "TextureManager.h"

#include <gl\glew.h>
#include <cstdlib>
#include <ctime>

StockObjectLoader::StockObjectLoader()
{
	srand((unsigned int)time(NULL));
}

StockObjectLoader::~StockObjectLoader()
{
}

void StockObjectLoader::loadAssets()
{
	//BMPTextureLoader loader;
	//OGLObject *object;

	//object = new Axis("Axes", 3.0f);
	//gameObjectManager->addObject("Axes", object);

	//object = new OGLTexturedFlatSurface("Ground", 20, 20, 10, 10);
	//gameObjectManager->addObject("Ground", object);

	//object = new OGLTexturedFlatSurface("Left Wall", 20, 10, 10, 5);
	//object->referenceFrame.rotateWorldX(90);
	//object->referenceFrame.rotateWorldY(90);
	//object->referenceFrame.translateWorld(-10, 5, 0);
	//gameObjectManager->addObject("Left Wall", object);

	//object = new OGLTexturedFlatSurface("Back Wall", 20, 10, 10, 5, {1, 1, 0, 1});
	//object->referenceFrame.rotateWorldX(90);
	//object->referenceFrame.translateWorld(0, 5, -10);
	//gameObjectManager->addObject("Back Wall", object);

	//object = new OGLTexturedFlatSurface("Right Wall", 20, 10, 10, 5);
	//object->referenceFrame.rotateWorldX(90);
	//object->referenceFrame.rotateWorldY(-90);
	//object->referenceFrame.translateWorld(10, 5, 0);
	//gameObjectManager->addObject("Right Wall", object);

	//object = new OGLTexturedFlatSurface("Roof", 20, 20, 10, 10);
	//object->referenceFrame.rotateWorldX(180);
	//object->referenceFrame.translateWorld(0, 10, 0);
	//gameObjectManager->addObject("Roof", object);

	//object = new Sphere("Sphere", 1, 20, 20, { 0.9f, 0.8f, 1.0f, 1 });
	//object->material.shininess = 200;
	//object->material.specular = { 1, 1, 1, 1 };
	//object->referenceFrame.rotateWorldY(90.0f);
	//object->referenceFrame.rotateWorldZ(150.0f);
	//object->referenceFrame.translateWorld(7, 2, -7);
	//gameObjectManager->addObject("Sphere", object);

	//object = new Cuboid("Cuboid");
	//object->referenceFrame.translate(0, 3, -8);
	//gameObjectManager->addObject("Cuboid", object);

	//object = new Turret("Turret");
	//gameObjectManager->addObject("Turret", object);

	//object = new Arm("Left Arm");
	//gameObjectManager->addObject("Left Arm", object);

	//Arm *arm = (Arm*)object;

	//object = new Sword("Sword");
	//gameObjectManager->addObject("Sword", object);

	//arm->addSword((Sword*)object);

}
