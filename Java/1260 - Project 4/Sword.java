
import java.util.Random;
public class Sword {
public static void main(String[] args) {

String string = "";
Random r = new Random();

for(int i = 0;i<50;i++) {
int rand = r.nextInt(100);
if(rand<44) {
string=string+"a";
}
else if(rand>=44 & rand<66) {
string=string+"b";
}
else if(rand >=66 && rand<96) {
string=string+"c";
}
else if(rand>=96) {
string=string+"d";
}
}
System.out.println(string);
}
}