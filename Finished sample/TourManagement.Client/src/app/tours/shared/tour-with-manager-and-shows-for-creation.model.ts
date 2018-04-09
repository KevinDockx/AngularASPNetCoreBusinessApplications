import { TourWithManagerForCreation } from "./tour-with-manager-for-creation.model";
import { ShowForCreation } from "../shows/shared/show-for-creation.model";

export class TourWithManagerAndShowsForCreation extends TourWithManagerForCreation {
    shows: ShowForCreation[];
}
