<template>
  <div class='home'>
    <img alt='Vue logo' src='../assets/logo.png'>
    <div class='home'>
      <p v-if='isLoggedIn'>User: {{ this.currentUser }}</p>
      <button class='btn' @click='login' v-if='!isLoggedIn'>Login</button>
      <button class='btn' @click='logout' v-if='isLoggedIn'>Logout</button>
      <button class='btn' @click='getProtectedApiData' v-if='isLoggedIn'>Get API data</button>
    </div>

    <div v-if='notes && notes.length'>
      <div v-for='n of notes'>
        <p><em>Id:</em> {{ n.id }} <em>Details:</em> {{ n.title }}</p>
      </div>
      <br/>
    </div>

  </div>
</template>
<script>
import {loadUser,signinRedirect,signoutRedirect} from '@/service/main'
import userManager from '@/service/main'
import axios from 'axios';


export default {
  name: "HomeView",
  data() {
    return {
      currentUser: '',
      accessTokenExpired: false,
      isLoggedIn: false,
      notes: [],
    }
  },
  methods: {
    login() {
      signinRedirect();
    }
    ,
    logout() {
      signoutRedirect();
    },
    getProtectedApiData() {
      const authorizationHeader = 'Authorization';
      userManager.getUser().then((userToken) => {
        axios.defaults.headers.common[authorizationHeader] = `Bearer ${userToken.access_token}`;
        axios.get('https://localhost:5001/api/Notes/')
            .then((response) => {
              this.notes = response.data;
            })
            .catch((error) => {
              alert(error);
            });
      });
    }
  }
  ,
  mounted() {
    loadUser();
    userManager.getUser().then((user) => {
      if (user){
        this.currentUser = user.profile.name;
        this.accessTokenExpired = user.expired;
        this.isLoggedIn = (user !== null && !user.expired);
      }

    });
  }
}
</script>

<style>
.btn {
  color: #42b983;
  cursor: pointer;
  font-weight: bold;
  background-color: #007bff;
  border-color: #007bff;
  display: inline-block;
  font-weight: 400;
  text-align: center;
  vertical-align: middle;
  -webkit-user-select: none;
  -moz-user-select: none;
  -ms-user-select: none;
  user-select: none;
  background-color: transparent;
  border: 1px solid #42b983;
  padding: .375rem .75rem;
  margin: 10px;
  font-size: 1rem;
  line-height: 1.5;
  border-radius: .25rem;
  transition: color .15s ease-in-out, background-color .15s ease-in-out, border-color .15s ease-in-out, box-shadow .15s ease-in-out;
}
</style>