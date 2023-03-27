export class Review {
    id: number = 0;
    name = "";
    description = "";
    star: number = 5;
    date = new Date().toISOString();
    person = "";
    reservation = "";
}