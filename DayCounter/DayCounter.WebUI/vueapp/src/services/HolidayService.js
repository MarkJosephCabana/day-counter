
import axios from 'axios';

export default class HolidayService {
    static async GetWeekdays(start, end) {
        return await axios.get(`/days/${start}/${end}`);
    }

    static async GetBusinessWeekdays(start, end) {
        return await axios.get(`/businessdays/${start}/${end}`);
    }
}