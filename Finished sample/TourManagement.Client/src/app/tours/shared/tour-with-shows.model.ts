import { Tour } from "./tour.model";
import { Show } from "../shows/shared/show.model";

export class TourWithShows extends Tour {
    shows: Show[];
}