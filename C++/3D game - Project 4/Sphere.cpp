#include "Sphere.h"
#include "ObjectGenerator.h"

Sphere::Sphere(const string& name, float radius, int slices, int stacks, RGBA surfaceColor) :
	OGL3DObject(name)
{
	this->radius = radius;
	this->slices = slices;
	this->stacks = stacks;
	this->surfaceColor = surfaceColor;
	this->generate();
}

Sphere::~Sphere()
{
}

void Sphere::generate()
{
	this->setIndexedArrayType();
	ElementArray arr = 
		ObjectGenerator::generateSphere(
			this->radius, this->slices, this->stacks, this->surfaceColor);
	this->setVertexData(arr.vertexData);
	this->setIndexData(arr.indexData);
	VBOObject* vboObject = OGLObject::createVBOObject(
		"triangles", arr.vertexData, arr.indexData, GL_TRIANGLES);
	this->addVBOObject(vboObject);
}
