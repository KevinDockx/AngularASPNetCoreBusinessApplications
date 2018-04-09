import { TourWithEstimatedProfits } from "./tour-with-estimated-profits.model";
import { Show } from "../shows/shared/show.model";

export class TourWithEstimatedProfitsAndShows extends TourWithEstimatedProfits {
    shows: Show[];
}
