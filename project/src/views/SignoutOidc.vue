<template>
  <div>Waiting..</div>
</template>

<script>
import {signoutRedirectCallback} from "@/service/main";

export default {
  name: "SignoutOidc",
  async mounted() {
    try {
      let result = await signoutRedirectCallback();
      let returnToUrl = '/';
      if (result.state !== undefined) {
        returnToUrl = result.state;
      }
      this.$router.push({path: returnToUrl});
    } catch (e) {
      this.$router.push({name: 'Unauthorized'});
    }
  }
}
</script>

<style scoped>

</style>