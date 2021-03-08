import axios from "axios";

export default class HolidayService {
    static async GetWeekdays(start, end) {
        return await axios.get(`/days/${start}/${end}`);
    }

    static async GetBusinessWeekdays(start, end) {
        return await axios.get(`/businessdays/${start}/${end}`);
    }

    static async GetSpecialBusinessWeekdays(start, end) {
        return await axios.get(`/businessdays/special/${start}/${end}`);
    }

    static async GetHolidays() {
        return await axios.get(`/holidays`);
    }

    static async GetAllHolidays() {
        return await axios.get(`/holidays/special`);
    }
}
