export class Reservation {
    id?: number;
    person = "";
    boatType = "";
    location = "";
    date = new Date().toISOString();
    isPaid?: boolean;
}