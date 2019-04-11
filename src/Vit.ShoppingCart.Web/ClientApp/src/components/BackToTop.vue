<template>
  <v-scale-transition>
    <v-btn v-if="visible" bottom floating fixed right fab dark color="primary" @click="$vuetify.goTo(0)">
      <v-icon dark>mdi-arrow-up</v-icon>
    </v-btn>
  </v-scale-transition>
</template>

<script>
export default {
  props: {
    offset: {
      type: Number,
      default: 400
    }
  },
  data() {
    return {
      visible: false
    };
  },
  mounted() {
    window.addEventListener('scroll', this.onScroll);
  },
  destroyed() {
    window.removeEventListener('scroll', this.onScroll);
  },
  methods: {
    onScroll() {
      this.visible = window.scrollY >= this.offset;
    }
  }
};
</script>
