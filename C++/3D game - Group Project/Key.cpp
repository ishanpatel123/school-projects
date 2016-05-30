#include "Key.h"
#include "ObjectGenerator.h"

Key::Key(const string& name) : OGL3DObject("Key")
{
	this->generate();
}


Key::~Key()
{
}

void Key::generate()
{
	ObjectGenerator gen;
	gen.clear();

	// Positions {x, y, z, w} 
	// Front
	float depth = 0;
	gen.positions[0] = { -4, 1, depth, 1 };
	gen.positions[1] = { -4, 0, depth, 1 };
	gen.positions[2] = { -3, 0, depth, 1 };
	gen.positions[3] = { -3, 1, depth, 1 };

	gen.positions[4] = { -3, 2, depth, 1 };
	gen.positions[5] = { -3, -1, depth, 1 };

	gen.positions[6] = { -2, -1, depth, 1 };
	gen.positions[7] = { -2, 0, depth, 1 };

	gen.positions[8] = { -2, 1, depth, 1 };
	gen.positions[9] = { -2, 2, depth, 1 };

	gen.positions[10] = { -1, 1, depth, 1 };
	gen.positions[11] = { -1, 0, depth, 1 };

	gen.positions[12] = { 4, 1, depth, 1 };
	gen.positions[13] = { 4, 0, depth, 1 };

	gen.positions[14] = { 1, 0, depth, 1 };
	gen.positions[15] = { 1, -1, depth, 1 };
	gen.positions[16] = { 2, -1, depth, 1 };
	gen.positions[17] = { 2, 0, depth, 1 };

	gen.positions[18] = { 3, 0, depth, 1 };
	gen.positions[19] = { 3, -1, depth, 1 };
	gen.positions[20] = { 4, -1, depth, 1 };

	// Back
	depth = -0.5;

	gen.positions[21] = { -4, 1, depth, 1 };
	gen.positions[22] = { -4, 0, depth, 1 };
	gen.positions[23] = { -3, 0, depth, 1 };
	gen.positions[24] = { -3, 1, depth, 1 };

	gen.positions[25] = { -3, 2, depth, 1 };
	gen.positions[26] = { -3, -1, depth, 1 };

	gen.positions[27] = { -2, -1, depth, 1 };
	gen.positions[28] = { -2, 0, depth, 1 };

	gen.positions[29] = { -2, 1, depth, 1 };
	gen.positions[30] = { -2, 2, depth, 1 };

	gen.positions[31] = { -1, 1, depth, 1 };
	gen.positions[32] = { -1, 0, depth, 1 };

	gen.positions[33] = { 4, 1, depth, 1 };
	gen.positions[34] = { 4, 0, depth, 1 };

	gen.positions[35] = { 1, 0, depth, 1 };
	gen.positions[36] = { 1, -1, depth, 1 };
	gen.positions[37] = { 2, -1, depth, 1 };
	gen.positions[38] = { 2, 0, depth, 1 };

	gen.positions[39] = { 3, 0, depth, 1 };
	gen.positions[40] = { 3, -1, depth, 1 };
	gen.positions[41] = { 4, -1, depth, 1 };

	// Generate Faces
	gen.addTriangleAndGenerateNormals({ 0, 1, 2 });
	gen.addTriangleAndGenerateNormals({ 0, 2, 3 });
	gen.addTriangleAndGenerateNormals({ 4, 0, 3 });
	gen.addTriangleAndGenerateNormals({ 1, 5, 2 });
	gen.addTriangleAndGenerateNormals({ 2, 5, 6 });
	gen.addTriangleAndGenerateNormals({ 2, 6, 7 });
	gen.addTriangleAndGenerateNormals({ 4, 3, 8 });
	gen.addTriangleAndGenerateNormals({ 4, 8, 9 });
	gen.addTriangleAndGenerateNormals({ 9, 8, 10 });
	gen.addTriangleAndGenerateNormals({ 7, 6, 11 });
	gen.addTriangleAndGenerateNormals({ 8, 7, 11 });
	gen.addTriangleAndGenerateNormals({ 8, 11, 10 });
	gen.addTriangleAndGenerateNormals({ 10, 11, 13 });
	gen.addTriangleAndGenerateNormals({ 10, 13, 12 });
	gen.addTriangleAndGenerateNormals({ 14, 15, 16 });
	gen.addTriangleAndGenerateNormals({ 14, 16, 17 });
	gen.addTriangleAndGenerateNormals({ 18, 19, 20 });
	gen.addTriangleAndGenerateNormals({ 18, 20, 13 });

	gen.addTriangleAndGenerateNormals({ 2 + 21, 1 + 21, 0 + 21 });
	gen.addTriangleAndGenerateNormals({ 3 + 21, 2 + 21, 0 + 21 });
	gen.addTriangleAndGenerateNormals({ 3 + 21, 0 + 21, 4 + 21 });
	gen.addTriangleAndGenerateNormals({ 2 + 21, 5 + 21, 1 + 21 });
	gen.addTriangleAndGenerateNormals({ 6 + 21, 5 + 21, 2 + 21 });
	gen.addTriangleAndGenerateNormals({ 7 + 21, 6 + 21, 2 + 21 });
	gen.addTriangleAndGenerateNormals({ 8 + 21, 3 + 21, 4 + 21 });
	gen.addTriangleAndGenerateNormals({ 9 + 21, 8 + 21, 4 + 21 });
	gen.addTriangleAndGenerateNormals({ 10 + 21, 8 + 21, 9 + 21 });
	gen.addTriangleAndGenerateNormals({ 11 + 21, 6 + 21, 7 + 21 });
	gen.addTriangleAndGenerateNormals({ 11 + 21, 7 + 21, 8 + 21 });
	gen.addTriangleAndGenerateNormals({ 10 + 21, 11 + 21, 8 + 21 });
	gen.addTriangleAndGenerateNormals({ 13 + 21, 11 + 21, 10 + 21 });
	gen.addTriangleAndGenerateNormals({ 12 + 21, 13 + 21, 10 + 21 });
	gen.addTriangleAndGenerateNormals({ 16 + 21, 15 + 21, 14 + 21 });
	gen.addTriangleAndGenerateNormals({ 17 + 21, 16 + 21, 14 + 21 });
	gen.addTriangleAndGenerateNormals({ 20 + 21, 19 + 21, 18 + 21 });
	gen.addTriangleAndGenerateNormals({ 13 + 21, 20 + 21, 18 + 21 });

	// Sides
	gen.positions[42] = gen.positions[21];
	gen.positions[43] = gen.positions[22];
	gen.positions[44] = gen.positions[1];
	gen.positions[45] = gen.positions[0];
	gen.addTriangleAndGenerateNormals({ 42, 43, 44 });
	gen.addTriangleAndGenerateNormals({ 42, 44, 45 });

	gen.positions[46] = gen.positions[25];
	gen.positions[47] = gen.positions[21];
	gen.positions[48] = gen.positions[0];
	gen.positions[49] = gen.positions[4];
	gen.addTriangleAndGenerateNormals({ 46, 47, 48 });
	gen.addTriangleAndGenerateNormals({ 46, 48, 49 });

	gen.positions[50] = gen.positions[30];
	gen.positions[51] = gen.positions[25];
	gen.positions[52] = gen.positions[4];
	gen.positions[53] = gen.positions[9];
	gen.addTriangleAndGenerateNormals({ 50, 51, 52 });
	gen.addTriangleAndGenerateNormals({ 50, 52, 53 });

	gen.positions[54] = gen.positions[31];
	gen.positions[55] = gen.positions[30];
	gen.positions[56] = gen.positions[9];
	gen.positions[57] = gen.positions[10];
	gen.addTriangleAndGenerateNormals({ 54, 55, 56 });
	gen.addTriangleAndGenerateNormals({ 54, 56, 57 });

	gen.positions[58] = gen.positions[33];
	gen.positions[59] = gen.positions[31];
	gen.positions[60] = gen.positions[10];
	gen.positions[61] = gen.positions[12];
	gen.addTriangleAndGenerateNormals({ 58, 59, 60 });
	gen.addTriangleAndGenerateNormals({ 58, 60, 61 });

	gen.positions[62] = gen.positions[12];
	gen.positions[63] = gen.positions[20];
	gen.positions[64] = gen.positions[20 + 21];
	gen.positions[65] = gen.positions[12 + 21];
	gen.addTriangleAndGenerateNormals({ 62, 63, 64 });
	gen.addTriangleAndGenerateNormals({ 62, 64, 65 });

	gen.positions[66] = gen.positions[20];
	gen.positions[67] = gen.positions[19];
	gen.positions[68] = gen.positions[19 + 21];
	gen.positions[69] = gen.positions[20 + 21];
	gen.addTriangleAndGenerateNormals({ 66, 67, 68 });
	gen.addTriangleAndGenerateNormals({ 66, 68, 69 });

	gen.positions[70] = gen.positions[18 + 21];
	gen.positions[71] = gen.positions[19 + 21];
	gen.positions[72] = gen.positions[19];
	gen.positions[73] = gen.positions[18];
	gen.addTriangleAndGenerateNormals({ 70, 71, 72 });
	gen.addTriangleAndGenerateNormals({ 70, 72, 73 });

	gen.positions[74] = gen.positions[17 + 21];
	gen.positions[75] = gen.positions[18 + 21];
	gen.positions[76] = gen.positions[18];
	gen.positions[77] = gen.positions[17];
	gen.addTriangleAndGenerateNormals({ 74, 75, 76 });
	gen.addTriangleAndGenerateNormals({ 74, 76, 77 });

	gen.positions[78] = gen.positions[17];
	gen.positions[119] = gen.positions[16];
	gen.positions[120] = gen.positions[16 + 21];
	gen.positions[121] = gen.positions[17 + 21];
	gen.addTriangleAndGenerateNormals({ 78, 119, 120 });
	gen.addTriangleAndGenerateNormals({ 78, 119, 121 });

	gen.positions[79] = gen.positions[16];
	gen.positions[80] = gen.positions[15];
	gen.positions[81] = gen.positions[15 + 21];
	gen.positions[82] = gen.positions[16 + 21];
	gen.addTriangleAndGenerateNormals({ 79, 80, 81 });
	gen.addTriangleAndGenerateNormals({ 79, 81, 82 });

	gen.positions[83] = gen.positions[14 + 21];
	gen.positions[84] = gen.positions[15 + 21];
	gen.positions[85] = gen.positions[15];
	gen.positions[86] = gen.positions[14];
	gen.addTriangleAndGenerateNormals({ 83, 84, 85 });
	gen.addTriangleAndGenerateNormals({ 83, 85, 86 });

	gen.positions[87] = gen.positions[11 + 21];
	gen.positions[88] = gen.positions[14 + 21];
	gen.positions[89] = gen.positions[14];
	gen.positions[90] = gen.positions[11];
	gen.addTriangleAndGenerateNormals({ 87, 88, 89 });
	gen.addTriangleAndGenerateNormals({ 87, 89, 90 });

	gen.positions[91] = gen.positions[11];
	gen.positions[92] = gen.positions[6];
	gen.positions[93] = gen.positions[6 + 21];
	gen.positions[94] = gen.positions[11 + 21];
	gen.addTriangleAndGenerateNormals({ 91, 92, 93 });
	gen.addTriangleAndGenerateNormals({ 91, 93, 94 });

	gen.positions[95] = gen.positions[6];
	gen.positions[96] = gen.positions[5];
	gen.positions[97] = gen.positions[5 + 21];
	gen.positions[98] = gen.positions[6 + 21];
	gen.addTriangleAndGenerateNormals({ 95, 96, 97 });
	gen.addTriangleAndGenerateNormals({ 95, 97, 98 });

	gen.positions[99] = gen.positions[1 + 21];
	gen.positions[100] = gen.positions[5 + 21];
	gen.positions[101] = gen.positions[5];
	gen.positions[102] = gen.positions[1];
	gen.addTriangleAndGenerateNormals({ 99, 100, 101 });
	gen.addTriangleAndGenerateNormals({ 99, 101, 102 });

	gen.positions[103] = gen.positions[3];
	gen.positions[104] = gen.positions[2];
	gen.positions[105] = gen.positions[2 + 21];
	gen.positions[106] = gen.positions[3 + 21];
	gen.addTriangleAndGenerateNormals({ 103, 104, 105 });
	gen.addTriangleAndGenerateNormals({ 103, 105, 106 });

	gen.positions[107] = gen.positions[8];
	gen.positions[108] = gen.positions[3];
	gen.positions[109] = gen.positions[3 + 21];
	gen.positions[110] = gen.positions[8 + 21];
	gen.addTriangleAndGenerateNormals({ 107, 108, 109 });
	gen.addTriangleAndGenerateNormals({ 107, 109, 110 });

	gen.positions[111] = gen.positions[2];
	gen.positions[112] = gen.positions[7];
	gen.positions[113] = gen.positions[7 + 21];
	gen.positions[114] = gen.positions[2 + 21];
	gen.addTriangleAndGenerateNormals({ 111, 112, 113 });
	gen.addTriangleAndGenerateNormals({ 111, 113, 114 });

	gen.positions[115] = gen.positions[8 + 21];
	gen.positions[116] = gen.positions[7 + 21];
	gen.positions[117] = gen.positions[7];
	gen.positions[118] = gen.positions[8];
	gen.addTriangleAndGenerateNormals({ 115, 116, 117 });
	gen.addTriangleAndGenerateNormals({ 115, 117, 118 });

	// Colors {r, g, b, a}
	for (int i = 0; i < 122; i++)
	{
		gen.colors[i] = { 1, 1, 0, 1 };
	}

	float* vertexData = gen.generateVertexData();
	short* indexData = gen.generateIndexData();

	this->createElementArrayPCN("Triangles", vertexData, indexData, GL_TRIANGLES);
}
