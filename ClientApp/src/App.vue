<script setup lang="ts">
import useBookStore from "./stores/bookStore";
import { onMounted } from "vue";
import ListItem from "./components/ListItem.vue";
import ListItemAdder from "./components/ListItemAdder.vue";
import ListItemBook from "./components/ListItemBook.vue";
import ActionButton from "./components/ActionButton.vue";

const bookStore = useBookStore();

onMounted(async () => {
  await bookStore.initBooksStore;
});
</script>

<template>
  <div class="flex flex-col h-full gap-4 items-center justify-center">
    <ul
      class="flex flex-col gap-0.5 w-4/5 p-1 bg-slate-500 border border-black rounded"
    >
      <ListItem>
        <p>Title</p>
        <p>Author</p>
        <p>Release Year</p>
        <p>Actions</p>
      </ListItem>
      <ListItemBook
        v-for="item in bookStore.getBooks"
        :book="item"
      ></ListItemBook>
      <ListItemAdder />
    </ul>
    <ActionButton class="max-w-xs max-h-8" @action="bookStore.syncChanges">
      Save Changes
    </ActionButton>
  </div>
</template>
