<template>
  <div class="about">
    <v-row>
      <v-col cols="3">
        <v-date-picker v-model="dates" range @change="onDateChange"></v-date-picker>
      </v-col>
      <v-col cols="5" min-height="70vh" rounded="lg">
        <v-card class="py-0 fill-height">
          <v-card-title>Weekday counter</v-card-title>
          <v-card-text>
            <v-row
              align="center"
              class="mx-0"
            >Calculates the number of weekdays in between two dates.</v-row>
          </v-card-text>
          <v-divider class="mx-4"></v-divider>
          <v-card-title>{{ rangeText }}</v-card-title>
          <v-card-text>
            <v-row align="center" class="mx-0">Total weekdays is {{ weekdays }}</v-row>
          </v-card-text>
        </v-card>
      </v-col>
      <v-col></v-col>
    </v-row>
  </div>
</template>

<script>
import moment from "moment";
import HolidayService from "../services/HolidayService";
const dateFormat = "YYYY-MM-DD";

export default {
  name: "TaskOne",
  methods: {
    onDateChange: function() {
      var start = moment.utc(this.dates[0], dateFormat).unix(),
        end = moment.utc(this.dates[1], dateFormat).unix();

      HolidayService.GetWeekdays(start, end).then(result => {
        this.weekdays = result.data;
      });
    }
  },
  computed: {
    rangeText: function() {
      var start = moment.utc(this.dates[0], dateFormat).format(dateFormat),
        end = moment.utc(this.dates[1], dateFormat).format(dateFormat);
      return `${start} ~ ${end}`;
    }
  },
  data: () => {
    return {
      dates: [moment().format(dateFormat), moment().format(dateFormat)],
      weekdays: 0
    };
  }
};
</script>

<style>
.about {
  width: 100%;
}
</style>
