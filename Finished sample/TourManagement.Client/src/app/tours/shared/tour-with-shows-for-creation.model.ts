import { TourForCreation } from "./tour-for-creation.model";
import { ShowForCreation } from "../shows/shared/show-for-creation.model";

export class TourWithShowsForCreation extends TourForCreation {
    shows: ShowForCreation[];
}
