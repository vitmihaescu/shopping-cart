<template>
  <v-container>
    <v-layout column mb-5>
      <h1 class="font-weight-light display-1">About</h1>
      <v-flex>
        <p>A simple shopping cart application build with ASP.NET Core and Vue.js</p>
        <h2 class="font-weight-regular">Used Technology Stack</h2>
        <h3 class="mt-3 mb-1 font-weight-regular">ASP.NET Core 2.2:</h3>
        <ul>
          <li>WebAPI</li>
          <li>JavaScript Services middleware to integrate with client app</li>
          <li>AWS Custom Runtime entry point to deploy to AWS Lambda</li>
        </ul>
        <h3 class="mt-3 mb-1 font-weight-regular">Vue 2</h3>
        <ul>
          <li>Vue Router</li>
          <li>Vuex</li>
          <li>Vuetify</li>
        </ul>
        <h2 class="font-weight-regular mt-4 mb-2">Prerequisites</h2>
        <ul>
          <li>.NET Core SDK >= 2.2</li>
          <li>NodeJs >= 8.9</li>
          <li>Vue CLI >= 3.0</li>
        </ul>
        <h2 class="font-weight-regular mt-4 mb-2">Source Code</h2>
        <a href="https://github.com/vitmihaescu/shopping-cart">https://github.com/vitmihaescu/shopping-cart</a>
      </v-flex>
    </v-layout>
  </v-container>
</template>
