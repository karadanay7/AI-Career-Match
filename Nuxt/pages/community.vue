<template>
    <div class="min-h-screen bg-gray-100 dark:bg-gray-900 py-10">
      <div class="max-w-2xl mx-auto">
        <!-- Page Title -->
      
  
        <!-- New Post Section -->
        <UCard class=" p-6 rounded-lg shadow-md mb-6">
          <div class="flex items-start space-x-4">
            <img
              class="h-12 w-12 rounded-full object-cover"
              src="/images/avatar-placeholder.png"
              alt="User Avatar"
            />
            <div class="flex-1">
              <UTextarea v-model="newPostContent" placeholder="What's on your mind?"> </UTextarea>
             
              <div class="flex justify-end space-x-4 mt-4">
                <UButton @click="addPost" label="Share" size="md"/>
               
              </div>
            </div>
          </div>
        </UCard>
  
        <!-- Posts Section -->
        <UCard v-for="post in posts" :key="post.id" class=" p-6 rounded-lg shadow-md mb-6">
          <div class="flex items-start space-x-4">
            <img
              class="h-12 w-12 rounded-full object-cover"
              :src="post.user.avatar"
              alt="User Avatar"
            />
            <div class="flex-1">
              <div class="flex justify-between items-center">
                <div>
                  <p class="font-semibold text-gray-900 dark:text-gray-100">{{ post.user.name }}</p>
                  <p class="text-sm text-gray-500 dark:text-gray-400">{{ post.timestamp }}</p>
                </div>
                <div class="flex space-x-4">
                  <button @click="likePost(post)" class="text-sky-500 hover:underline">{{ post.likes }} Likes</button>
                  <button @click="repostPost(post)" class="text-gray-500 dark:text-gray-400 hover:underline">Repost</button>
                </div>
              </div>
              <p class="mt-4 text-gray-900 dark:text-gray-100">{{ post.content }}</p>
              <div v-for="comment in post.comments" :key="comment.id" class="mt-4 pl-4 border-l border-gray-300 dark:border-gray-700">
                <div class="flex items-start space-x-2">
                  <img
                    class="h-8 w-8 rounded-full object-cover"
                    :src="comment.user.avatar"
                    alt="Comment User Avatar"
                  />
                  <div>
                    <p class="font-semibold text-gray-900 dark:text-gray-100">{{ comment.user.name }}</p>
                    <p class="text-sm text-gray-500 dark:text-gray-400">{{ comment.timestamp }}</p>
                    <p class="mt-2 text-gray-900 dark:text-gray-100">{{ comment.content }}</p>
                  </div>
                </div>
              </div>
              <UTextarea  v-model="newCommentContent" placeholder="Add a comment..." class="mt-2" />

           
            
              <UButton @click="addComment(post)" label="Comment" size="md" class="mt-2"/>
            </div>
          </div>
        </Ucard>
      </div>
    </div>
  </template>
  
  <script setup lang="ts">

  
  // Example data
  const posts = reactive([
    {
      id: 1,
      user: {
        name: 'John Doe',
    avatar: '/images/avatar-placeholder.png'
      },
      timestamp: '2 hours ago',
      content: 'Hey everyone! I am currently looking for a job in web development. Any advice or leads would be greatly appreciated!',
      likes: 10,
      comments: [
        {
          id: 1,
          user: {
            name: 'Jane Smith',
          avatar: '/images/avatar-placeholder.png'
          },
          timestamp: '1 hour ago',
          content: 'Hi John! You might want to check out XYZ Company, they are currently hiring frontend developers.'
        }
      ]
    },
    {
      id: 2,
      user: {
        name: 'Emily Johnson',
           avatar: '/images/avatar-placeholder.png'
      },
      timestamp: '5 hours ago',
      content: 'I just completed a new project on GitHub. It’s a Vue.js app for tracking expenses. Would love to get some feedback!',
      likes: 25,
      comments: [
        {
          id: 2,
          user: {
            name: 'Mike Wilson',
      avatar: '/images/avatar-placeholder.png'
          },
          timestamp: '4 hours ago',
          content: 'Great job, Emily! The UI looks clean and the functionality is very smooth.'
        },
        {
          id: 3,
          user: {
            name: 'Sarah Brown',
          avatar: '/images/avatar-placeholder.png'
          },
          timestamp: '3 hours ago',
          content: 'Awesome work, Emily! I’ll check it out and give you my feedback soon.'
        }
      ]
    }
  ]);
  
  const newPostContent = ref('');
  const newCommentContent = ref('');
  
  function addPost() {
    if (newPostContent.value.trim()) {
      posts.unshift({
        id: posts.length + 1,
        user: {
          name: 'You',
          avatar: '/images/avatar-placeholder.png'
        },
        timestamp: 'Just now',
        content: newPostContent.value,
        likes: 0,
        comments: []
      });
      newPostContent.value = '';
    }
  }
  
  function likePost(post) {
    post.likes += 1;
  }
  
  function repostPost(post) {
    posts.unshift({
      ...post,
      id: posts.length + 1,
      user: {
        name: 'You',
      avatar: '/images/avatar-placeholder.png'
      },
      timestamp: 'Just now'
    });
  }
  
  function addComment(post) {
    if (newCommentContent.value.trim()) {
      post.comments.push({
        id: post.comments.length + 1,
        user: {
          name: 'You',
            avatar: '/images/avatar-placeholder.png'
        },
        timestamp: 'Just now',
        content: newCommentContent.value
      });
      newCommentContent.value = '';
    }
  }
  </script>
  
  <style scoped>
  </style>
  