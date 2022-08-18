interface User {
  name: string;
  id: number;
}
 
const user: User = {
  name: "Hayes",
  id: 0,
};
function t():User{
  return user
}
let x=t()
x.id